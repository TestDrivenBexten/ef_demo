using System.ComponentModel.DataAnnotations;

namespace EfDemo.Entities
{
    public class ShareTransaction
    {
        [Key]
        public int ShareTransactionId { get; set; }
        public decimal BalanceChange { get; set; }
    }
}
