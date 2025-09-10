using MauiShopElectronics.Models;
using MauiShopElectronics.Models.models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.models
{
    public class Records
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        public int UserId { get; set; }
        public string ProductRecordsJson { get; set; }
        public List<ProductBascket> Products { get; set; }
        public DateOnly DateOnly { get; set; }
		public MethodOfReceipt MethodOfReceipt { get; set; }
		public int AllPriceRecords { get; set; }
    }
}
