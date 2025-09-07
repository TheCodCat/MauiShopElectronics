using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using Models.models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;

namespace MauiShopElectronics.ViewModels
{
    public partial class CategoriesProductViewModel : ObservableObject
    {
        private IServiceProvider _serviceProvider;
        private RestClient client = new RestClient();
        public Page _page;

        [ObservableProperty]
        private Categorie categorie;

        [ObservableProperty]
        private List<Product> products = new List<Product>();

        [ObservableProperty]
        private List<string> allcategorie = new List<string>();

        [ObservableProperty]
        private ObservableCollection<string> selectCaterogie = new ObservableCollection<string>();

        public CategoriesProductViewModel(Categorie categorie, Page page, IServiceProvider serviceProvider)
        {
            Categorie = categorie;
            _page = page;
            _serviceProvider = serviceProvider;
            Allcategorie = serviceProvider.GetService<MainViewModel>().Categorias.Select(x => x.Title).ToList();

            SelectCaterogie = new ObservableCollection<string>(Allcategorie.ToList());
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
            await _page.Navigation.PushAsync(new ProductPage(product,_serviceProvider));
        }
    }
}
