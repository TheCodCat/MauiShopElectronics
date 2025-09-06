using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Models.models;

namespace MauiShopElectronics.Models.models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        [ForeignKey("CategorieId")] public Categorie Categorie { get; set; }
        public int CategorieId { get; set; }
        [ForeignKey("BrandId")] public Brand Brand { get; set; }
        public int BrandId { get; set; }
		public string ProductRecordsBytes { get; set; }

		public Product(string name, string description, Brand brand, Categorie categorie, string bytes, int price)
        {
            ProductName = name;
            ProductDescription = description;
            Categorie = categorie;
            Brand = brand;
            ProductRecordsBytes = bytes;
            ProductPrice = price;
        }
    }
}
