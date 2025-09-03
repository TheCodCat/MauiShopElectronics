using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Models.models;
using Microsoft.Extensions.Configuration;
using Models.models;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class CategoriesProductViewModel : ObservableObject
    {
        private RestClient client;
        private Categorie categorie;
        private IConfiguration _configuration;
        [ObservableProperty]
        private List<Product> products = new List<Product>();

        public CategoriesProductViewModel(Categorie categorie)
        {
            this.categorie = categorie;
        }

        public async void OnApperaining()
        {
            string urlGet = _configuration.GetSection("ConnectionStrings").GetSection("GetProdurts").Value;
            var request = new RestRequest(urlGet, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            }
        }
    }
}
