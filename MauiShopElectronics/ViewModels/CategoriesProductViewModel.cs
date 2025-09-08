using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using Models.models;
using RestSharp;

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
        private List<Categorie> allcategorie = new List<Categorie>();

        [ObservableProperty]
        private int selectCaterogie;

        public CategoriesProductViewModel(Categorie categorie, Page page, IServiceProvider serviceProvider)
        {
            Categorie = categorie;
            _page = page;
            _serviceProvider = serviceProvider;
            Allcategorie = serviceProvider.GetService<MainViewModel>().Categorias;
        }
        public async void OnApperaining()
        {
            var request = await _serviceProvider.GetService<RequestHandler>().GetProductCategorie(Categorie);

            Products = request;
        }

        [RelayCommand]
        public async void SelectProduct(Product product)
        {
            await _page.Navigation.PushAsync(new ProductPage(product,_serviceProvider));
        }

        partial void OnSelectCaterogieChanging(int oldValue, int newValue)
        {
            ChangeProducts(newValue);
        }

        private async void ChangeProducts(int id)
        {
            if (id < 0)
                Products = await _serviceProvider.GetService<RequestHandler>().GetAllProducts();
            else
            {
                var categories = _serviceProvider.GetService<MainViewModel>().Categorias;
                var categorie = categories.FirstOrDefault(x => x.Title == allcategorie[id].Title);
                Products = await _serviceProvider.GetService<RequestHandler>().GetProductCategorie(categorie);
            }
        }
    }
}
