using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class CreditCard信用卡
    {
        public CreditCard信用卡()
        {
            Member會員s = new HashSet<Member會員>();
        }

        public int Cid信用卡流水號 { get; set; }
        public string Cname信用卡公司名 { get; set; }
        public string Cnum信用卡號 { get; set; }
        public bool? Cuse使用狀態 { get; set; }

        public virtual ICollection<Member會員> Member會員s { get; set; }
    }
}
