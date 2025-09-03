using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Models.models;

namespace MauiShopElectronics.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product product;
    }
}
