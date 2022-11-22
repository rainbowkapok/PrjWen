using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class Member會員
    {
        public int Id會員編號 { get; set; }
        public string Name會員名稱 { get; set; }
        public string Email信箱 { get; set; }
        public string Phone手機號碼 { get; set; }
        public int Cid信用卡流水號 { get; set; }

        public virtual CreditCard信用卡 Cid信用卡流水號Navigation { get; set; }
    }
}
