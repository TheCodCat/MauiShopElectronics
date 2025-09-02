using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Product
    {

        [Key] public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Product(): this("Пусто","Пусто")
        {
        }

        public Product(string name, string description)
        {
            ProductName = name;
            ProductDescription = description;
        }
    }
}
