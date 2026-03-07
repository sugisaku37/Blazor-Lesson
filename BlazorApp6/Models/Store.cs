using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Models
{
    [Table("stores")]
    public class Store
    {
        [Column("stor_id"), Required, MaxLength(4), Key]
        public string StoreId { get; set; } = null!;

        [Column("stor_name"), Required, MaxLength(40)]
        public string StoreName { get; set; } = null!;

        [Column("stor_addr"), Required, MaxLength(40)]
        public string Address { get; set; } = null!;

        [Column("city"), Required, MaxLength(20)]
        public string City { get; set; } = null!;

        [Column("state"), Required, MaxLength(22)]
        public string State { get; set; } = null!;

        [Column("zip"), Required, MaxLength(5)]
        public string Zip { get; set; } = null!;

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}