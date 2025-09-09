using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using Microsoft.Extensions.DependencyInjection;
using Models.models;
using System;

namespace MauiShopElectronics.ViewModels
{
	public partial class BascketViewModel : ObservableObject
	{
		private readonly IServiceProvider _serviceProvider;
		[ObservableProperty]
		private List<ProductBascket> productBasckets = new List<ProductBascket>();

        [ObservableProperty]
        private int countBascketProduct;

        [ObservableProperty]
		private int allPrice;

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

		partial void OnProductBascketsChanging(List<ProductBascket>? oldValue, List<ProductBascket> newValue)
		{
			AllPrice = newValue.Sum(x => x.Product.ProductPrice * x.Count);
			CountBascketProduct = newValue.Sum(x => x.Count);
		}
		[RelayCommand]
		public async void AddCountProduct(ProductBascket productBascket)
		{
			productBascket.Count++;
			var requestHandler = _serviceProvider.GetService<RequestHandler>();

			var result = await requestHandler.ChangeCountProductBascket(productBascket);

			if(result)
				ProductBasckets = await requestHandler.GetUserBascket(_serviceProvider.GetService<UserController>().User.Value.Id);
		}

		[RelayCommand]
		public async void MinusCountProduct(ProductBascket productBascket)
		{
			productBascket.Count--;
			var requestHandler = _serviceProvider.GetService<RequestHandler>();

			bool result;
			if(productBascket.Count <= 0)
			{
				result = await requestHandler.RemoteProductBascket(productBascket);
			}
			else
			{
				result = await requestHandler.ChangeCountProductBascket(productBascket);
			}

			if (result)
				ProductBasckets = await requestHandler.GetUserBascket(_serviceProvider.GetService<UserController>().User.Value.Id);
		}
		[RelayCommand]
		public async void SelectProduct(ProductBascket product)
		{
			await Shell.Current.Navigation.PushAsync(new ProductPage(product.Product, _serviceProvider));
		}

		[RelayCommand]
		public async void OrderProducts()
		{
			var requiredService = _serviceProvider.GetService<RequestHandler>();

			RecordsDTO recordsDTO = new RecordsDTO()
			{
				DateOnly = DateOnly.FromDateTime(DateTime.Now),
				Products = ProductBasckets,
				UserId = _serviceProvider.GetService<AuthorizationViewModel>().User.Id,
			};

			var result = await requiredService.OrderProducts(recordsDTO);

			//if(result)
   //             ProductBasckets.Clear();

        }
	}
}
