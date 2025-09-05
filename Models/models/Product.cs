using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.models
{
    public class Product
    {

        [Key] public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [ForeignKey("CategorieId")] public Categorie Categorie { get; set; }
        public int CategorieId { get; set; }
        [ForeignKey("BrandId")] public Brand Brand { get; set; }
        public int BrandId { get; set; }
		public string ProductRecordsBytes { get; set; }

		public Product(): this("Пусто","Пусто",new Brand(), new Categorie(), string.Empty)
        {
        }

        public Product(string name, string description,Brand brand, Categorie categorie, string bytes )
        {
            ProductName = name;
            ProductDescription = description;
            Categorie = categorie;
            Brand = brand;
            ProductRecordsBytes = bytes;
        }
    }
}
