using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class Product
    {   
        // Ürün ifadesinin içereceği değerleri, propertyleri tanımlıyoruz.
        public int ProductId { get; set; }
        
        [Required] // Name değerinin zorunlu olarak doldurulması gerektiğini ifade etmektedir.
        // Name değeri harf sayısının hangi aralıkta olması gerektiğini ve değilse dönecek olan hata mesajını ifade etmektedir.
        [StringLength(60,MinimumLength=10,ErrorMessage="Ürün ismi 10-60 karakter arasında olmalıdır.")] 
        public string Name { get; set; } 

        [Required(ErrorMessage="Fiyat Girmelisiniz.")]
        [Range(1,10000)]
        public double? Price { get; set; } 
        public string Description { get; set; } 
        [Required]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        
        [Required]
        public int? CategoryId { get; set; }
    }
}