using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication10.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Boş geçilemez")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Email Boş geçilemez")]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        [EmailAddress(ErrorMessage = "Email formatı şeklinde giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı Boş geçilemez")]
        [Display(Name = "UserName")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş geçilemez")]
        [Display(Name = "Sifre")]
        [StringLength(50, ErrorMessage = "Max 10 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Boş geçilemez")]
        [Display(Name = "Sifre")]
        [StringLength(50, ErrorMessage = "Max 10 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string RePassword { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 karakter olamalıdır.")]
        public string Role { get; set; }
    }
}
