using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Brand
    {
        [Key] public int Id { get; set; }
        public string BrandName { get; set; }

        public Brand() : this("Нет названия")
        {

        }
        public Brand(string brandName)
        {
            BrandName = brandName;
        }
    }
}
