using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Model
{
    [Table("sales")]
    public class Sale
    {
        // ※ 複合キーは Data Annotation で指定できないため、Fluent API を使う
        [Column("stor_id"), Required, MaxLength(4)]
        public string StoreId { get; set; } = null!;

        [Column("ord_num"), Required, MaxLength(20)]
        public string OrderNumber { get; set; } = null!;

        [Column("ord_date"), Required]
        public DateTime OrderDate { get; set; }

        [Column("qty"), Required]
        public int Quantity { get; set; }

        [Column("payterms"), Required, MaxLength(12)]
        public string PayTerms { get; set; } = null!;

        [Column("title_id"), Required, MaxLength(6)]
        public string TitleId { get; set; } = null!;

        public Store Store { get; set; } = null!;

        public Title Title { get; set; } = null!;
    }
}