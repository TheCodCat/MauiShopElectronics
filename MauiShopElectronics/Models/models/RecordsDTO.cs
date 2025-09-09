using MauiShopElectronics.Pages;
using Models.models;

namespace MauiShopElectronics.Models.models
{
	public class RecordsDTO
	{
		public int UserId { get; set; }
		public List<ProductBascket> Products { get; set; }
        public DateOnly DateOnly { get; set; }
    }
}
