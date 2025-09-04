using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Models.models;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly IConfiguration _configuration;
        RestClient client = new RestClient();

        [ObservableProperty] 
        private List<Categorie> categories = new List<Categorie>();

        [ObservableProperty]
        private string nameNewCategories = string.Empty;

        public AdminViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Apperaining()
        {
            string url = _configuration.GetSection("ConnectionStrings").GetSection("GetCategories").Value;
            var request = new RestRequest(url,Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Categories = JsonConvert.DeserializeObject<List<Categorie>>(response.Content);
            }
        }
    }
}
