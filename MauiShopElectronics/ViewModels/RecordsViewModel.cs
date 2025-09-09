using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Services;
using Models.models;

namespace MauiShopElectronics.ViewModels
{
    public partial class RecordsViewModel : ObservableObject
    {
        private IServiceProvider serviceProvider;

        [ObservableProperty]
        private List<Records> records = new List<Records>();

        public RecordsViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            GetRecords(this.serviceProvider.GetService<UserController>().User.Value.Id);
        }

        public async void GetRecords(int userId)
        {
            var request = serviceProvider.GetService<RequestHandler>();

            var result = await request.GetReviews(userId);
        }
    }
}
