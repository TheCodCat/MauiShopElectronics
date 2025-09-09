using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class RecordsPage : ContentPage
{
	private readonly RecordsViewModel viewModel;
	public RecordsPage(RecordsViewModel recordsViewModel)
	{
		InitializeComponent();
		viewModel = recordsViewModel;
		BindingContext = viewModel;
	}
}