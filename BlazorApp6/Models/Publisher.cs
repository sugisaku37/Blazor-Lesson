using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Models
{
    [Table("publishers")]
    public class Publisher
    {
        [Column("pub_id"), Required, MaxLength(4)]
        public string PublisherId { get; set; } = null!;

        [Column("pub_name"), MaxLength(40)]
        public string? PublisherName { get; set; }

        [Column("city"), MaxLength(20)]
        public string? City { get; set; }

        [Column("state"), MaxLength(2)]
        public string? State { get; set; }

        [Column("country"), MaxLength(30)]
        public string? Country { get; set; }

        public ICollection<Title> Titles { get; set; } = new HashSet<Title>();
    }
}