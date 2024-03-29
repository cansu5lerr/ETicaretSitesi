﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Açıklama")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Fiyat")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Stok")]

        public int Stock { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Popüler")]

        public bool Popular { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Onay")]

        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Ad Boş geçilemez")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Sales> Sales { get; set; }
        public virtual List<Cart> Carts { get; set; }
    }
}
