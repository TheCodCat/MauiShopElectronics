using MauiShopElectronics.ViewModels;
using Models.models;
using System.Collections.ObjectModel;
using UraniumUI.Material.Controls;
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

    private void MultiplePickerField_SelectedValuesChanged(object sender, object e)
    {
        var item = ((ObservableCollection<object>)sender);
    }
}