using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace formula_API.Models
{
    public class Formula
    {
        [Key]
        public int FormulaId { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "jsonb")]
        public string StepsData { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
