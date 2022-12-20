using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Cart
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
        public int UserId { get; set; }
    }
}
