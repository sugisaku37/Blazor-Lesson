using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Model
{
    [Table("authors")]
    public class Author
    {
        [Column("au_id"), Required, MaxLength(11), Key]
        public string AuthorId { get; set; } = null!;

        [Column("au_fname"), Required, MaxLength(20)]
        public string AuthorFirstName { get; set; } = null!;

        [Column("au_lname"), Required, MaxLength(40)]
        public string AuthorLastName { get; set; } = null!;

        [Column("phone"), Required, MaxLength(12)]
        public string Phone { get; set; } = null!;

        [Column("address"), MaxLength(40)]
        public string? Address { get; set; }

        [Column("city"), MaxLength(20)]
        public string? City { get; set; }

        [Column("state"), MaxLength(2)]
        public string? State { get; set; }

        [Column("zip"), MaxLength(5)]
        public string? Zip { get; set; }

        [Column("contract"), Required]
        public bool Contract { get; set; }

        [Column("rowversion"), Timestamp, ConcurrencyCheck]
        public byte[]? RowVersion { get; set; }

        public ICollection<TitleAuthor> TitleAuthors { get; set; } = new HashSet<TitleAuthor>();
    }
}