
using Newtonsoft.Json;
using Northwind.Entities.Concrete;
using Northwind.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace Northwind.Entities.Dtos
{
    public class CategoryAddDto
    {
        public CategoryAddDto()
        {
            //Products = new HashSet<Product>();
            
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //[JsonConverter(typeof(Base64FileJsonConverter))]
        public byte[] Picture { get; set; }
        
    }


}
