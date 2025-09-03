using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using Models.models;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class CategoriesProductViewModel : ObservableObject
    {
        private RestClient client = new RestClient();
        private Categorie categorie;
        public Page _page;

        [ObservableProperty]
        private List<Product> products = new List<Product>();

        public CategoriesProductViewModel(Categorie categorie, Page page)
        {
            this.categorie = categorie;
            _page = page;
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

        [RelayCommand]
        public async void SelectProduct(Product product)
        {
            await _page.Navigation.PushAsync(new ProductPage(product));
        }
    }
}
