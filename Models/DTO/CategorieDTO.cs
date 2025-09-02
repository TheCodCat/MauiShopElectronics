namespace Models.DTO
{
    public class CategorieDTO
    {
        public string CategorieTitle { get; set; }

        public CategorieDTO() : this("Нету")
        {

        }

        public CategorieDTO(string title)
        {
            CategorieTitle = title;
        }
    }
}
