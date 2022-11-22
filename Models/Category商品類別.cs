using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class Category商品類別
    {
        public Category商品類別()
        {
            Product商品s = new HashSet<Product商品>();
        }

        public int Id類別編號 { get; set; }
        public string CategoryName類別名稱 { get; set; }

        public virtual ICollection<Product商品> Product商品s { get; set; }
    }
}
