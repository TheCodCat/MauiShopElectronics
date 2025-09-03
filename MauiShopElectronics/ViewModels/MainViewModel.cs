using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Models.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace MauiShopElectronics.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private IConfiguration _configuration;

        [ObservableProperty]
        private List<Product> products = new List<Product>();

        public MainViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void Apperaining()
        {
            string urlGet = _configuration.GetSection("ConnectionStrings").GetSection("GetProdurts").Value;
            var client = new RestClient();
            var request = new RestRequest(urlGet,Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                Products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
        }
    }
}
