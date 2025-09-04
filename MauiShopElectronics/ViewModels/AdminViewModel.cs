using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Models.models;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace MauiShopElectronics.ViewModels
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly IConfiguration _configuration;
        RestClient client = new RestClient();

        [ObservableProperty] 
        private List<Categorie> categories = new List<Categorie>();

        [ObservableProperty]
        private List<string> categoriesString = new List<string>();

        [ObservableProperty]
        private string nameNewCategories = string.Empty;

        [ObservableProperty]
        private string nameNewBrand = string.Empty;

        [ObservableProperty]
        private string indexRemoteCategorie;


        [ObservableProperty]
        private List<Brand> brands = new List<Brand>();

        [ObservableProperty]
        private string indexRemoteBrands;

        [ObservableProperty]
        private List<string> brandsString = new List<string>();

        partial void OnCategoriesChanging(List<Categorie>? oldValue, List<Categorie> newValue)
        {
            CategoriesString = newValue?.Select(x => x.Title).ToList() ?? new List<string>();
        }

        partial void OnBrandsChanging(List<Brand>? oldValue, List<Brand> newValue)
        {
            BrandsString = newValue?.Select(x => x.BrandName).ToList() ?? new List<string>();
        }

        public AdminViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Apperaining()
        {
            GetCategories();
            GetBrands();
        }

        private async void GetCategories()
        {
            string url = _configuration.GetSection("ConnectionStrings").GetSection("GetCategories").Value;
            var request = new RestRequest(url, Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Categories = JsonConvert.DeserializeObject<List<Categorie>>(response.Content);
            }
        }

        private async void GetBrands()
        {
            string url = _configuration.GetSection("ConnectionStrings").GetSection("GetBrands").Value;
            var request = new RestRequest(url,Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Brands = JsonConvert.DeserializeObject<List<Brand>>(response.Content);
            }
        }

        [RelayCommand]
        public async void CreateCategory()
        {
            CategorieDTO categorie = new CategorieDTO(NameNewCategories);
            string json = JsonConvert.SerializeObject(categorie);

            NameNewCategories = string.Empty;

            string url = _configuration.GetSection("ConnectionStrings").GetSection("CreateCategorie").Value;

            RestRequest restRequest = new RestRequest(url, Method.Post);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);

            var result = await client.ExecuteAsync(restRequest);

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
                GetCategories();

        }

        [RelayCommand] 
        public async void RemoveCategory()
        {
            if (IndexRemoteCategorie == null) return;

            int index = Categories.FirstOrDefault(x => x.Title == IndexRemoteCategorie).Id;
            string url = $"{_configuration.GetSection("ConnectionStrings").GetSection("RemoteCategorie").Value}/{index}";
            var request = new RestRequest(url, Method.Post);
            RestResponse response = await client.ExecuteAsync(request);

            GetCategories();
        }

        [RelayCommand]
        public async void CreateBrands()
        {
            string url = _configuration.GetSection("ConnectionStrings").GetSection("AddBrands").Value;
            var request = new RestRequest(url,Method.Post);
            request.AddHeader("Content-Type", "application/json");

            string json = JsonConvert.SerializeObject(new Brand(NameNewBrand));

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                GetBrands();
                NameNewBrand = string.Empty;
            }

        }

        [RelayCommand]
        public async void RemoveBrand()
        {
            int index = Brands.FirstOrDefault(x => x.BrandName == IndexRemoteBrands).Id;
            string url = $"{_configuration.GetSection("ConnectionStrings").GetSection("RemoteBrands").Value}/{index}";
            var request = new RestRequest(url,Method.Post);
            RestResponse response = await client.ExecuteAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                GetBrands();
            }
        }
        
    }
}
