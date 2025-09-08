using MauiShopElectronics.ViewModels;
using Models.models;
using UraniumUI.Pages;

namespace MauiShopElectronics.Pages;

public partial class CategoriesProductsPage : UraniumContentPage
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