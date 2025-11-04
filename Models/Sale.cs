using System.ComponentModel.DataAnnotations.Schema;

namespace BazarUniversalAPI.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
