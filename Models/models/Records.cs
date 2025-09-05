using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.models
{
    public class Records
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        public int UserId { get; set; }
        public string ProductRecords { get; set; }
        public byte[] ProductRecordsBytes { get; set; }
    }
}
