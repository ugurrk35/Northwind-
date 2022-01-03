using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Dtos
{
    public  class CustomerAddDto
    {
        public CustomerAddDto()
        {
            // CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
            //  Orders = new HashSet<Order>();
        }
        [DisplayName("Şirket Adı")]
        [Required(ErrorMessage = "{0} Adı Boş geçilemez")]
        [MaxLength(40,ErrorMessage ="{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string CompanyName { get; set; }
        [DisplayName("İletişim Adı")]
        [Required(ErrorMessage = "{0} Adı Boş geçilemez")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string ContactName { get; set; }
        
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string ContactTitle { get; set; }
        [DisplayName("Adress")]
    
        [MaxLength(60, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string Address { get; set; }
        [DisplayName("Şehir")]
      
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string City { get; set; }
        [DisplayName("Eyalet")]
        [Required(ErrorMessage = "{0} Adı Boş geçilemez")]
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string Region { get; set; }
        [DisplayName("Posta Kodu")]
       
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string PostalCode { get; set; }
        [DisplayName("Ülke")]
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string Country { get; set; }
        [DisplayName("Telefon")]
       
        [MaxLength(24, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string Phone { get; set; }
        [DisplayName("Fax")]

        [MaxLength(24, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        public string Fax { get; set; }
    }
}
