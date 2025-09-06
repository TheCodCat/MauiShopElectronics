using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiShopElectronics.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        public RequestHandler _handler;
        public readonly IServiceProvider serviceProvider;

        public ProductViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            user = serviceProvider.GetRequiredService<UserController>().User.Value;
            _handler = serviceProvider.GetService<RequestHandler>();
        }

        [ObservableProperty]
        private Product product;

        [ObservableProperty]
        private bool isRequired;

		[ObservableProperty]
        private User user;

        [RelayCommand]
        public async void AddProductBasket(Product product)
        {
            if (_handler.userController.User.Value == null)
            {
                await Shell.Current.Navigation.PushAsync(new AuthorizationPage(serviceProvider.GetService<AuthorizationViewModel>()));
                return;
            }
            IsRequired = true;
            var result = await _handler.AddProductBascket(product);
            IsRequired = false;
        }
    }
}
