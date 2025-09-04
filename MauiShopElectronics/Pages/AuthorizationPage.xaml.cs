using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages;

public partial class AuthorizationPage : ContentPage
{
	public AuthorizationPage(AuthorizationViewModel authorizationViewModel)
	{
		InitializeComponent();
		BindingContext = authorizationViewModel;
		authorizationViewModel._page = this;
	}
}