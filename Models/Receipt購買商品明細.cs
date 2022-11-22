using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class Receipt購買商品明細
    {
        public int Rid明細編號 { get; set; }
        public int OrdId訂單編號 { get; set; }
        public int Id產品編號 { get; set; }
        public int Qty數量 { get; set; }

        public virtual Product商品 Id產品編號Navigation { get; set; }
        public virtual Order訂單總表 OrdId訂單編號Navigation { get; set; }
    }
}
