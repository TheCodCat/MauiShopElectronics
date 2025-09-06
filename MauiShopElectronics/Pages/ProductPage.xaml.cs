using MauiShopElectronics.Models.models;
using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class ProductPage : ContentPage
{
	private ProductViewModel _productViewModel;
	public ProductPage(Product product, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		_productViewModel = new ProductViewModel(serviceProvider);
		_productViewModel.Product = product;
		BindingContext = _productViewModel;
	}

	protected override void OnAppearing()
	{
		_productViewModel.OnAperaining();
		base.OnAppearing();
	}
}