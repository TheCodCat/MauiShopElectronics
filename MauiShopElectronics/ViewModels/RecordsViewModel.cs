using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Services;
using Models.models;
using Newtonsoft.Json;

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

            var result = await request.GetRecords(userId);
            if (result.Count == 0) return;

            foreach (var item in result)
            {
                item.Products = JsonConvert.DeserializeObject<List<ProductBascket>>(item.ProductRecordsJson);
                item.AllPriceRecords = item.Products.Select(x => x.Product.ProductPrice * x.Count).Sum();
            }

            Records = result;
        }
    }
}
