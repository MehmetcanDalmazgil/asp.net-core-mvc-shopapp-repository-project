using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index() // localhost:5001/product/index
        {
            var product = new Product {Name="Iphone X",Price=6000,Description="güzel telefon"};
            ViewBag.Category = "Telefonlar";

            return View(product);
        }
        public IActionResult list(int? id,string q,double? min_price,double? max_price) // localhost:5001/product/list
        // Soru işareti null değer olabileceğin ifade etmektedir.
        {
            var products = ProductRepository.Products; // Ürün değerlerini ilgili property yardımıyla alıyoruz.

            if (id!=null)
            {
                products = products.Where(p=>p.CategoryId==id).ToList(); // Parametre olarak gelen id değeri ile aynı id değerine sahip ürünü alıyoruz.
            }

            if (!string.IsNullOrEmpty(q)) // q değeri boş değilse
            {
                products = products.Where(i=>i.Name.Contains(q) || i.Description.Contains(q)).ToList(); // q ifadesini içerisinde name veya description olarak barındıran ürün değerini alıyoruz.
            }

            var productViewModel = new ProductViewModel() // View'a gönderilecek model yapımız.
            {
                Products =products
            };

            return View(productViewModel);
        }

        [HttpGet] // Default olarak gelmektedir.
        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id)); // Id'ye ait ürün bilgilerini alıp view'a veriyoruz.
        }

        [HttpGet]
        public IActionResult Create() // ?
        {           
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name"); 
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {                       
            if (ModelState.IsValid) // Herhangi bir hata var mı diye kontrol eder
            {
                    ProductRepository.AddProduct(p); // Yeni ürünü repoya ekliyoruz.
                    return RedirectToAction("list"); // Kullanıcıyı list sayfasına yönlendiriyoruz.
            }
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");

            return View(p);            
        }

        [HttpGet]
        public IActionResult Edit(int id) // ?
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name"); 
            return View(ProductRepository.GetProductById(id)); // İlgili id'ye ait nesnenin getirilmesini sağlıyoruz.
        }

        [HttpPost]
        public IActionResult Edit(Product p) // İlgili ürünü düzenleyen metod.
        {
            ProductRepository.EditProduct(p);
            return RedirectToAction("list");
        }
  
        [HttpPost]
        public IActionResult Delete(int ProductId) // İlgili id'ye ait olan ürünü silen metod.
        {
            ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("list");
        }
        
    }
}