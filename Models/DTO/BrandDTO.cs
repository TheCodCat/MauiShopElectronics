namespace Models.DTO
{
    public class BrandDTO
    {
        public string BrandName { get; set; }

        public BrandDTO() : this("нету")
        {

        }
        public BrandDTO(string name)
        {
            BrandName = name;
        }
    }
}
