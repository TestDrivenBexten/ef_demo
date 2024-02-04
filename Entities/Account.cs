using System.ComponentModel.DataAnnotations;

namespace EfDemo.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public ICollection<Share> Shares { get; set; } = new List<Share>();
    }
}
