
using Northwind.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Entities.Concrete
{
    public partial class Category : EntityBase, IEntity
    {
        public Category()
        {
           Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
       
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
