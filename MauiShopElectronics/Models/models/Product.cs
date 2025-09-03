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
        [ForeignKey("CategorieId")] public Categorie Categorie { get; set; }
        public int CategorieId { get; set; }
        [ForeignKey("BrandId")] public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public string ImageURL { get; set; }

        public Product() : this("Пусто", "Пусто", new Brand(), new Categorie(), string.Empty)
        {
        }

        public Product(string name, string description, Brand brand, Categorie categorie, string imageURL)
        {
            ProductName = name;
            ProductDescription = description;
            Categorie = categorie;
            Brand = brand;
            ImageURL = imageURL;
        }
    }
}
