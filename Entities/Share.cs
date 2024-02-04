using System.ComponentModel.DataAnnotations;

namespace EfDemo.Entities
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }
        public decimal ShareAmount { get; set; }
        public Account Account { get; set; } // Parent account
        public ICollection<ShareTransaction> ShareTransactions { get; set; } = new List<ShareTransaction>();
    }
}
