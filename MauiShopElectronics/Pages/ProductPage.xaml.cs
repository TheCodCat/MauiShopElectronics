using MauiShopElectronics.Models.models;
using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class ProductPage : ContentPage
{
	public ProductPage(Product product, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		var view = new ProductViewModel(serviceProvider);
		view.Product = product;
		BindingContext = view;
	}
}