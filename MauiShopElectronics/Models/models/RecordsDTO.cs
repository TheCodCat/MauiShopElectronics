using Models.models;
using Models;

namespace MauiShopElectronics.Models.models
{
	public class RecordsDTO
	{
		public int UserId { get; set; }
		public List<ProductBascket> Products { get; set; }
        public DateOnly DateOnly { get; set; }
		public MethodOfReceipt MethodOfReceipt { get; set; }
	}
}
