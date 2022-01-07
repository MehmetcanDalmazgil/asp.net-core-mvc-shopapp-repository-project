using System.Collections.Generic;
using System.Linq;

namespace shopapp.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories=null; // Private bir kategori oluşturuyoruz.

        // Verilerimizi tuttuğumuz dosya yapısı
        static CategoryRepository()
        {
            _categories = new List<Category> // Oluşturulan listeye nesneler ekliyoruz.
            {
                new Category {CategoryId=1,Name="Telefon",Description="Telefon Kategorisi"},
                new Category {CategoryId=2,Name="Bilgisayar",Description="Bilgisayar Kategorisi"},
                new Category {CategoryId=3,Name="Elektronik",Description="Elektronik Kategorisi"},
                new Category {CategoryId=4,Name="Kitap",Description="Kitap Kategorisi"}
            };
        }

        public static List<Category> Categories // Kategori nesnesini getiren metod.
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(Category category) // Kategori nesnesine ekleme yapan metod.
        {
            _categories.Add(category);
        }

        public static Category GetCategorybyId(int id) // Kategori nesnesi içerisinde bulunan bir değeri id değerine göre getiren metod.
        {
            return _categories.FirstOrDefault(c=>c.CategoryId==id);
        }



    }
}