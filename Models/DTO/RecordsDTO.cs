using Models.models;

namespace Models.DTO
{
	public class RecordsDTO
	{
		public int UserId { get; set; }
		public List<Product> Products { get; set; }
	}
}
