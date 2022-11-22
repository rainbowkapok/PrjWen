using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class Store各分店
    {
        public Store各分店()
        {
            Order訂單總表s = new HashSet<Order訂單總表>();
        }

        public int StoreId各店編號 { get; set; }
        public string StoreName店名 { get; set; }
        public string Address地址 { get; set; }
        public string Tel電話 { get; set; }

        public virtual ICollection<Order訂單總表> Order訂單總表s { get; set; }
    }
}
