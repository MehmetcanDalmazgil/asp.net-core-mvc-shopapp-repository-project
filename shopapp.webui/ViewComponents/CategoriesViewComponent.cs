using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;

namespace shopapp.webui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke() // Kategoriler sürekli kullanılan veriler olduğu için componenti oluşturulmaktadır.
        {
            if (RouteData.Values["action"].ToString()=="list") //  Eğer list sayfasında isek
                ViewBag.SelectedCategory = RouteData?.Values["id"]; // Seçilen kategori değerine id değerini atıyoruz.
            return View(CategoryRepository.Categories);
        }
    }
}