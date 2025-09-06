using MauiShopElectronics.Models.models;
using MauiShopElectronics.Services;
using Microsoft.Extensions.Configuration;
using Models.models;
using Newtonsoft.Json;
using RestSharp;

namespace MauiShopElectronics
{
	public class RequestHandler
	{
		private RestClient restClient = new RestClient();
		private readonly IConfiguration configuration;
		public readonly UserController userController;

		public RequestHandler(IConfiguration configuration, UserController userController)
		{
			this.configuration = configuration;
			this.userController = userController;
		}

		public async void AddProductBascket(Product product)
		{
			string url = configuration.GetSection("ConnectionStrings").GetSection("AddBascket").Value;

			var request = new RestRequest(url, Method.Post);

			ProductBascket productRecord = new ProductBascket();
			productRecord.User = userController.User.Value;
			productRecord.Product = product;
			productRecord.Count = 1;
			string json = JsonConvert.SerializeObject(productRecord);

			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json",json, ParameterType.RequestBody);
			RestResponse response = await restClient.ExecuteAsync(request);
		}

		public async Task<List<ProductBascket>> GetUserBascket(int userId)
		{
			string url = $"{configuration.GetSection("ConnectionStrings").GetSection("GetBascket").Value}/{userId}";

			var request = new RestRequest(url,Method.Get);
			RestResponse response = await restClient.ExecuteAsync(request);

			var result = JsonConvert.DeserializeObject<List<ProductBascket>>(response.Content);
			if (result is not null)
				return result;
			else
				return new List<ProductBascket>();
		}

		public async Task<bool> ChangeCountProductBascket(ProductBascket productBascket)
		{
			string url = configuration.GetSection("ConnectionStrings").GetSection("ChangeCountBascket").Value;
			var request = new RestRequest(url, Method.Put);
			string json = JsonConvert.SerializeObject(productBascket);

			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", json, ParameterType.RequestBody);

			RestResponse response = await restClient.ExecuteAsync(request);
			if(response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;

			else return false;
		}

		public async Task<bool> RemoteProductBascket(ProductBascket productBascket)
		{
			string url = configuration.GetSection("ConnectionStrings").GetSection("RemoteBascket").Value;
			var request = new RestRequest(url, Method.Delete);
			string json = JsonConvert.SerializeObject(productBascket);

			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", json, ParameterType.RequestBody);

			RestResponse response = await restClient.ExecuteAsync(request);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;

			else return false;
		}
	}
}
