using Models.models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public Categorie Categorie { get; set; }
        public Brand Brand { get; set; }
		public string ProductRecordsBytes { get; set; }
		public ProductDTO() : this("Пусто", "Пусто", new Brand(), new Categorie(), string.Empty, 0)
        {
        }
        public ProductDTO(string name, string description, Brand brand, Categorie categorie, string bytes, int price)
        {
            ProductName = name;
            ProductDescription = description;
            Brand = brand;
            Categorie = categorie;
            ProductRecordsBytes = bytes;
            ProductPrice = price;
        }
    }
}
