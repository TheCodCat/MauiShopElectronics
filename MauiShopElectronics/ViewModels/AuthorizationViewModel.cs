using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class AuthorizationViewModel : ObservableObject
    {
        private readonly IConfiguration _configuration;
        [ObservableProperty]
        private bool isRequired;

        [ObservableProperty]
        private bool isRequiredStatus;

        [ObservableProperty]
        private string login;
        [ObservableProperty]
        private string password;

        public AuthorizationViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [RelayCommand]
        public async void Registration()
        {
            string urlReg = _configuration.GetSection("ConnectionStrings").GetSection("Registration").Value;
            IsRequired = true;

            await Task.Delay(500);

            var client = new RestClient();
            var request = new RestRequest(urlReg,method: Method.Post);

            var authDTO = new AuthDTO(Login, Password);
            var json = JsonConvert.SerializeObject(authDTO);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);


            RestResponse restResponse = await client.ExecuteAsync(request);

            IsRequired = false;

            bool.TryParse(restResponse.Content, out bool IsRequiredStatus);
        }

        [RelayCommand]
        public async void Authorization()
        {
            string urlReg = _configuration.GetSection("ConnectionStrings").GetSection("Authorization").Value;
            IsRequired = true;

            await Task.Delay(500);

            var client = new RestClient();
            var request = new RestRequest(urlReg, method: Method.Post);

            var authDTO = new AuthDTO(Login, Password);
            var json = JsonConvert.SerializeObject(authDTO);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);


            RestResponse restResponse = await client.ExecuteAsync(request);

            IsRequired = false;
        }
    }
}
