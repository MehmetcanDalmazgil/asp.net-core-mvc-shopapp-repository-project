using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data; // Verilerin olduğu dosyayı dahil ediyoruz.
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController:Controller
    {      
        // Startup içerisinde belirlenen enpoint içerisinde bulunan controller değeri "home" olduğu zaman gelecek olan"action" değerlerine ait metodlar aşağıdadır.
        public IActionResult Index() // localhost:5001/home/index
        {
            var productViewModel = new ProductViewModel()
            {
                Products = ProductRepository.Products // Ürün verilerini property üzerinden alıyoruz.
            };

            return View(productViewModel); // Alınan ürün değerlerini ilgili view dosyasına gönderiyoruz.
        }

         // localhost:5000/home/about
        public IActionResult About() // localhost:5001/home/about
        {
            return View();
        }

         public IActionResult Contact() // localhost:5001/home/contact
        {
            return View("MyView"); // Bu şekilde view adıda verilebilmektedir.
        }
    }
}