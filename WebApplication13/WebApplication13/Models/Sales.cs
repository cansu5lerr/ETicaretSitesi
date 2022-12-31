using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication13.Models
{
    public class Sales
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int UrunId { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Display(Name = "Kullanıcı")]
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
