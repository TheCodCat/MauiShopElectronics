namespace Models.DTO
{
    public class ReviewsDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Evaluation { get; set; }
		public string Description { get; set; }
	}
}
