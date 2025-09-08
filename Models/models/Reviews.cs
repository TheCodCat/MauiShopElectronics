using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.models
{
    public class Reviews
    {
        [Key] public int Id { get; set; }
        [ForeignKey("ProductId")] public Product Product { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Evaluation { get; set; }
    }
}
