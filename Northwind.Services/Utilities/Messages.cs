using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Boyle bir kategori bulunamadı.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
        }

        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Makaleler bulunamadı.";
                return "Böyle bir makale bulunamadı.";
            }
            public static string Add(string productName)
            {
                return $"{productName} başlıklı makale başarıyla eklenmiştir.";
            }

            public static string Update(string productName)
            {
                return $"{productName} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} başlıklı makale başarıyla silinmiştir.";
            }
            public static string HardDelete(string productName)
            {
                return $"{productName} başlıklı makale başarıyla veritabanından silinmiştir.";
            }
        }
    }
}
