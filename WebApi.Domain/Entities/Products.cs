using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities
{
    public class Products : BaseEntity
    {
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitStock { get; set; }
        public DateTime CreateDate { get; set; }
        public int UnitOnOder { get; set; }
        public new bool IsActive { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    }
}
