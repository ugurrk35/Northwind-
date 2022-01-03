using Northwind.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Entities.Concrete
{
    public partial class OrderDetail : EntityBase, IEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
