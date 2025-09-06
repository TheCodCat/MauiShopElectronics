using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class BascketPage : ContentPage
{
	private readonly BascketViewModel viewModel;
	public BascketPage(BascketViewModel bascketViewModel)
	{
		InitializeComponent();
		viewModel = bascketViewModel;
		BindingContext = viewModel;
	}
	protected override void OnAppearing()
	{
		viewModel.Aperaining();
	}
}