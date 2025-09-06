using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using Models.models;

namespace MauiShopElectronics.ViewModels
{
	public partial class BascketViewModel : ObservableObject
	{
		private readonly IServiceProvider _serviceProvider;
		[ObservableProperty]
		private List<ProductBascket> productBasckets = new List<ProductBascket>();

		public BascketViewModel(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async void Aperaining()
		{
			var requestHandler = _serviceProvider.GetService<RequestHandler>();
			if (_serviceProvider.GetService<UserController>().User.Value != null)
			{
				ProductBasckets = await requestHandler.GetUserBascket(_serviceProvider.GetService<UserController>().User.Value.Id);
			}
			else
				await Shell.Current.Navigation.PushAsync(new AuthorizationPage(_serviceProvider.GetService<AuthorizationViewModel>()));

		}
	}
}
