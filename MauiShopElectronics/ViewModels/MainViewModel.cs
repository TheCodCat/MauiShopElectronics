using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using Microsoft.Extensions.Configuration;
using Models.models;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private IConfiguration _configuration;
        private IServiceProvider serviceProvider;
        private RestClient client = new RestClient();

        [ObservableProperty]
        private List<Categorie> categorias = new List<Categorie>();

        [ObservableProperty]
        private List<Product> products = new List<Product>();

        [ObservableProperty]
        private List<Product> hitsProducts = new List<Product>();

        [ObservableProperty]
        private bool isRequest;

        [ObservableProperty]
        private string searchIndex;

        public MainViewModel(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            this.serviceProvider = serviceProvider;
		}
        public async Task Apperaining()
        {
            string urlGet = _configuration.GetSection("ConnectionStrings").GetSection("GetProdurts").Value;
            var request = new RestRequest(urlGet, Method.Get);

            IsRequest = true;

            RestResponse response = await client.ExecuteAsync(request);
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
                HitsProducts = Products.Take(10).ToList();
            }

            string urlCategories = _configuration.GetSection("ConnectionStrings").GetSection("GetCategories").Value;
            response = await client.ExecuteAsync(new RestRequest(urlCategories, Method.Get));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Categorias = JsonConvert.DeserializeObject<List<Categorie>>(response.Content);
            }

            IsRequest = false;
        }

        [RelayCommand]
        public async void SelectProduct(Product product)
        {
            await Shell.Current.Navigation.PushAsync(new ProductPage(product, serviceProvider));
        }

        [RelayCommand]
        public async void SelectCategories(Categorie categorie)
        {
            await Shell.Current.Navigation.PushAsync(new CategoriesProductsPage(categorie, serviceProvider));
        }


        partial void OnSearchIndexChanging(string? oldValue, string newValue)
        {
            var item = Products.FirstOrDefault(x => $"{x.Brand.BrandName} {x.ProductName}" == newValue);

            if(item is not null)
            {
                SelectProduct(item);
            }
        }

        [RelayCommand]
        private async void OpenToChanel()
        {
            string url = _configuration.GetSection("configuration").Value;
            if(url is not null)
                await Browser.Default.OpenAsync(url);
        }
    }
}
