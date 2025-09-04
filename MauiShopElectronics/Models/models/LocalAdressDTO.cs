namespace MauiShopElectronics.Models.models
{
    public class LocalAdressDTO
    {
        public int UserId { get; set; }
        public string NewLocalAdress { get; set; } = string.Empty;

        public LocalAdressDTO()
        {

        }
        public LocalAdressDTO(int id, string adress)
        {
            UserId = id;
            NewLocalAdress = adress;
        }
    }
}
