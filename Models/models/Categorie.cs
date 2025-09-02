using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Categorie
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }

        public Categorie() : this ("Нету")
        {

        }

        public Categorie(string value)
        {
            Title = value;
        }
    }
}
