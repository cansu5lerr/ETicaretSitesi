using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication13.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Açıklama Boş geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
