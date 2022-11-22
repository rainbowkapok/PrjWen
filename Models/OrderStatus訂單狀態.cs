using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class OrderStatus訂單狀態
    {
        public OrderStatus訂單狀態()
        {
            Order訂單總表s = new HashSet<Order訂單總表>();
        }

        public int OrdStatusId訂單狀態編號 { get; set; }
        public string OrdName訂單狀態名稱 { get; set; }

        public virtual ICollection<Order訂單總表> Order訂單總表s { get; set; }
    }
}
