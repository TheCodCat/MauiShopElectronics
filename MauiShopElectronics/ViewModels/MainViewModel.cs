using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Models.models;

namespace MauiShopElectronics.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Product> products = new List<Product>();
    }
}
