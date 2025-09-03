using MauiShopElectronics.Models.models;
using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class ProductPage : ContentPage
{
	public ProductPage(Product product)
	{
		InitializeComponent();
		var view = new ProductViewModel();
		view.Product = product;
		BindingContext = view;
	}
}