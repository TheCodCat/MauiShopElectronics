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
        private string indexRemoteCategorie;

        partial void OnCategoriesChanging(List<Categorie>? oldValue, List<Categorie> newValue)
        {
            CategoriesString = newValue.Select(x => x.Title).ToList();
        }

        public AdminViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Apperaining()
        {
            GetCategories();
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
        
    }
}
