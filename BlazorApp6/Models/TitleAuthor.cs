using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Models
{
    [Table("titleauthor")]
    public class TitleAuthor
    {
        [Column("au_id"), Required]
        public string AuthorId { get; set; } = null!;

        [Column("title_id"), Required]
        public string TitleId { get; set; } = null!;

        [Column("au_ord")]
        public byte? AuthorOrder { get; set; }

        [Column("royaltyper")]
        public int RoyaltyPercentage { get; set; }

        public Author Author { get; set; } = null!;

        public Title Title { get; set; } = null!;
    }
}