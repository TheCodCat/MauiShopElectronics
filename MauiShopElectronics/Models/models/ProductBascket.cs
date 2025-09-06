using MauiShopElectronics.Models.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.models
{
    public class ProductBascket
    {
        [Key] public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
