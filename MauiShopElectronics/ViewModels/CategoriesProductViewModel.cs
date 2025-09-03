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
        private RestClient client = new RestClient();
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
            string urlGet = "http://localhost:5073/getProducts/categories";
            var request = new RestRequest(urlGet, Method.Get);
            var json = JsonConvert.SerializeObject(categorie);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            RestResponse restResponse = await client.ExecuteAsync(request);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(restResponse.Content);
            }
        }
    }
}
