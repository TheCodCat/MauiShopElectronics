using Models.models;

namespace Models.DTO
{
	public class RecordsDTO
	{
		public int UserId { get; set; }
		public List<ProductBascket> Products { get; set; }
        public DateOnly DateOnly { get; set; }
    }
}
