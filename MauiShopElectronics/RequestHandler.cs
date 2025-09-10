using MauiShopElectronics.Models.models;
using MauiShopElectronics.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using Models.DTO;
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

		public async Task<bool> AddProductBascket(Product product)
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

			if(response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;

			return false;
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

		public async Task<List<Reviews>> GetReviews(int productId)
		{
			string url = $"{configuration.GetSection("ConnectionStrings").GetSection("GetReviews").Value}/{productId}";

			var request = new RestRequest(url, Method.Get);

            RestResponse response = await restClient.ExecuteAsync(request);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return JsonConvert.DeserializeObject<List<Reviews>>(response.Content);
			else
				return new List<Reviews>();
        }

		public async Task<bool> AddReviews(ReviewsDTO reviews)
		{
			string url = configuration.GetSection("ConnectionStrings").GetSection("AddReviews").Value;

			if (url == null)
				throw new ArgumentNullException("Ссылка не леквидна");

			string json = JsonConvert.SerializeObject(reviews);

            var request = new RestRequest(url,Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            RestResponse response = await restClient.ExecuteAsync(request);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			else return false;

        }
		public async Task<List<Product>> GetAllProducts()
		{
            string urlGet = configuration.GetSection("ConnectionStrings").GetSection("GetProdurts").Value;
            var request = new RestRequest(urlGet, Method.Get);
            RestResponse response = await restClient.ExecuteAsync(request);

			var products = new List<Product>();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
			}

			return products;
        }

		public async Task<List<Product>> GetProductCategorie(Categorie categorie)
		{
            string urlGet = "http://localhost:5073/getProducts/categories";
            var request = new RestRequest(urlGet, Method.Get);
            var json = JsonConvert.SerializeObject(categorie);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            RestResponse restResponse = await restClient.ExecuteAsync(request);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                 return JsonConvert.DeserializeObject<List<Product>>(restResponse.Content) ?? new List<Product>();
            }
			return new List<Product>();
        }

		public async Task<bool> OrderProducts(RecordsDTO recordsDTO)
		{
			string urlPost = configuration.GetSection("ConnectionStrings").GetSection("CreateRecorder").Value;
			var request = new RestRequest(urlPost, Method.Post);

			var json = JsonConvert.SerializeObject(recordsDTO);
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", json, ParameterType.RequestBody);

			RestResponse response = await restClient.ExecuteAsync(request);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			else
				return false;
		}

		public async Task<List<Records>> GetRecords(int userId)
		{
			string urlPost = $"{configuration.GetSection("ConnectionStrings").GetSection("GetRecorder").Value}/{userId}";
			var request = new RestRequest(urlPost, Method.Get);


			RestResponse response = await restClient.ExecuteAsync(request);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return JsonConvert.DeserializeObject<List<Records>>(response.Content);
			else
				return new List<Records>();
		}

		public async Task<List<Records>> GetRecords()
		{
			string urlPost = configuration.GetSection("ConnectionStrings").GetSection("GetRecorder").Value;
			var request = new RestRequest(urlPost, Method.Get);

			RestResponse response = await restClient.ExecuteAsync(request);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return JsonConvert.DeserializeObject<List<Records>>(response.Content);
			else
				return new List<Records>();
		}
	}
}
