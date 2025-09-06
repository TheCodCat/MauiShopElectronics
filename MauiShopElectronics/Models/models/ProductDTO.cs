namespace Models.models
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Categorie Categorie { get; set; }
        public Brand Brand { get; set; }
		public string ProductRecordsBytes { get; set; }
		public ProductDTO() : this("Пусто", "Пусто", new Brand(), new Categorie(), string.Empty)
        {
        }
        public ProductDTO(string name, string description, Brand brand, Categorie categorie, string value)
        {
            ProductName = name;
            ProductDescription = description;
            Brand = brand;
            Categorie = categorie;
            ProductRecordsBytes = value;
        }
    }
}
