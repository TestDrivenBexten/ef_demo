using System.ComponentModel.DataAnnotations;

namespace EfDemo
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }
        public decimal ShareAmount { get; set; }
    }
}
