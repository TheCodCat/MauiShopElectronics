using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShopElectronics.Models.models;
using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics.ViewModels
{
    public partial class AuthorizationViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly UserController _userController;
        private RestClient client = new RestClient();
        public Page _page;

        [ObservableProperty]
        private bool isRequired;

        [ObservableProperty]
        private bool isRequiredStatus;

        [ObservableProperty]
        private string login;
        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private string sity;

        [ObservableProperty]
        private string strit;

        [ObservableProperty]
        private string homeNumber;

        [ObservableProperty]
        private string fullAdress;

        partial void OnSityChanging(string? oldValue, string newValue)
        {
            GetFullAdress(newValue, Strit, HomeNumber);
        }
        partial void OnStritChanging(string? oldValue, string newValue)
        {
            GetFullAdress(Sity, newValue, HomeNumber);
        }
        partial void OnHomeNumberChanging(string? oldValue, string newValue)
        {
            GetFullAdress(Sity, Strit, newValue);
        }

        partial void OnUserChanging(User? oldValue, User newValue)
        {
            _userController.SetUser(newValue);
            FullAdress = newValue == null ? string.Empty : newValue.LocalAdress;
        }

        public AuthorizationViewModel(IConfiguration configuration,IServiceProvider serviceProvider, UserController userController)
        {
            _configuration = configuration;
            _userController = userController;
			_serviceProvider = serviceProvider;
			User = _userController.User.Value;
        }

        [RelayCommand]
        public async void Registration()
        {
            string urlReg = _configuration.GetSection("ConnectionStrings").GetSection("Registration").Value;
            IsRequired = true;

            await Task.Delay(500);

            var request = new RestRequest(urlReg,method: Method.Post);

            var authDTO = new AuthDTO(Login, Password);
            var json = JsonConvert.SerializeObject(authDTO);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);


            RestResponse restResponse = await client.ExecuteAsync(request);

            IsRequired = false;

            IsRequiredStatus = restResponse.StatusCode switch
            {
                System.Net.HttpStatusCode.OK => true,
                _ => false
            };
        }

        [RelayCommand]
        public async void Authorization()
        {
            string urlReg = _configuration.GetSection("ConnectionStrings").GetSection("Authorization").Value;
            IsRequired = true;

            await Task.Delay(500);

            var request = new RestRequest(urlReg, method: Method.Post);

            var authDTO = new AuthDTO(Login, Password);
            var json = JsonConvert.SerializeObject(authDTO);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            RestResponse restResponse = await client.ExecuteAsync(request);
            IsRequiredStatus = restResponse.StatusCode switch
            {
                System.Net.HttpStatusCode.OK => true,
                _=> false
            };

            IsRequired = false;

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                User = JsonConvert.DeserializeObject<User>(restResponse.Content);
            }
        }

        [RelayCommand]
        public async void EditProfile()
        {
            IsRequired = true;

            string editURL = _configuration.GetSection("ConnectionStrings").GetSection("Edit").Value;
            var request = new RestRequest(editURL, Method.Post);

            var json = JsonConvert.SerializeObject(User);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            RestResponse restResponse = await client.ExecuteAsync(request);
            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                User = JsonConvert.DeserializeObject<User>(restResponse.Content);
            }
            IsRequired = false;
        }

        [RelayCommand]
        public async void ExitAcount()
        {
            User = null;
        }

        [RelayCommand]
        public async void EditLocalAdress()
        {
            string url = _configuration.GetSection("ConnectionStrings").GetSection("EditLocalAdress").Value;
            var request = new RestRequest(url,Method.Post);
            request.AddHeader("Content-Type", "application/json");

            string json = JsonConvert.SerializeObject(new LocalAdressDTO(User.Id, FullAdress));
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Sity = string.Empty;
                Strit = string.Empty;
                HomeNumber = string.Empty;
                FullAdress = JsonConvert.DeserializeObject<LocalAdressDTO>(response.Content).NewLocalAdress;
            }
        }

        private void GetFullAdress(string sity, string strit, string homeNumber)
        {
            FullAdress = $"{sity}.{strit}.{homeNumber}";
        }

        [RelayCommand]
        public async void ToAdminPanel()
        {
            await _page.Navigation.PushAsync(new AdminPanelPage(_configuration, _serviceProvider));
        }
		[RelayCommand]
		public async void ToHistoryPanel()
		{
			await _page.Navigation.PushAsync(new RecordsPage(_serviceProvider.GetService<RecordsViewModel>()));
		}
	}
}
