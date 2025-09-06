using MauiShopElectronics.ViewModels;
using Models.models;

namespace MauiShopElectronics.Pages;

public partial class CategoriesProductsPage : ContentPage
{
	private CategoriesProductViewModel viewModel;
	public CategoriesProductsPage(Categorie categorie, IServiceProvider serviceProvider)
	{
		InitializeComponent();
        viewModel = new CategoriesProductViewModel(categorie, this, serviceProvider);
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.OnApperaining();
    }
}