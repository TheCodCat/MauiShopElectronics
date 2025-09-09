using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using Models.DTO;
using Models.models;

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
        private List<Reviews> reviews;

        [ObservableProperty]
        private bool isRequired;

		[ObservableProperty]
        private User user;

        [ObservableProperty]
        private ProductBascket currentProductBascket;

        [ObservableProperty]
        private string selectCount = "0";

        [ObservableProperty]
        private string reviewsDescription = string.Empty;

        public async void OnAperaining()
        {
            User = _handler.userController.User.Value;

            IsRequired = true;

            if (User != null)
			    GetCountProduct();

            Reviews = await _handler.GetReviews(Product.Id);

            IsRequired = false;
        }

        [RelayCommand]
        public async void AddProductBasket(Product product)
        {
            if (User == null)
            {
				await Shell.Current.Navigation.PushAsync(new AuthorizationPage(serviceProvider.GetService<AuthorizationViewModel>()));
                return;
            }
            IsRequired = true;

            var result = await _handler.AddProductBascket(product);
            if (result)
                GetCountProduct();

            IsRequired = false;
        }

        private async void GetCountProduct()
        {
            var result = await _handler.GetUserBascket(User.Id);

            var item = result.FirstOrDefault(x => x.Product.Id == Product.Id);

			if (item != null)
			{
                CurrentProductBascket = item;
			}
		}
        [RelayCommand]
        public async void AddReviews()
        {
            ReviewsDTO newReviews = new ReviewsDTO();
            newReviews.ProductId = Product.Id;
            newReviews.UserId = User.Id;
            newReviews.Description = reviewsDescription;

            if(int.TryParse(SelectCount, out int evaluation))
            newReviews.Evaluation = evaluation;

            var result = await _handler.AddReviews(newReviews);
            if(result)
				Reviews = await _handler.GetReviews(Product.Id);
		}
    }
}
