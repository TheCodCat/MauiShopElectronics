using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Models.models
{
    [DebuggerDisplay("{Id} - {Title}")]
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
