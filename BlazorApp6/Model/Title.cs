using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Model
{
    [Table("titles")]
    public class Title
    {
        [Column("title_id"), Required, MaxLength(6), Key]
        public string TitleId { get; set; } = null!;

        [Column("title"), Required, MaxLength(80)]
        public string TitleName { get; set; } = null!;

        [Column("type"), Required, MaxLength(12)]
        public string Type { get; set; } = null!;

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("advance")]
        public decimal? Advance { get; set; }

        [Column("royalty")]
        public int? Royalty { get; set; }

        [Column("ytd_sales")]
        public int? YearToDateSales { get; set; }

        [Column("notes"), MaxLength(200)]
        public string? Notes { get; set; }

        [Column("pubdate"), Required]
        public DateTime PublishedDate { get; set; }

        [Column("pub_id"), MaxLength(4)]
        public string? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        public ICollection<TitleAuthor> TitleAuthors { get; set; } = new HashSet<TitleAuthor>();
    }
}