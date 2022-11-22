using PrjWen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjWen.ViewModel
{
    public class CreditView
    {
        public List<MemberCredit> 信用卡;
    }
    public class MemberCredit
    {
        public int Cid信用卡流水號 { get; set; }
        public string Cname信用卡公司名 { get; set; }
        public string Cnum信用卡號 { get; set; }
        public virtual ICollection<Member會員> Member會員s { get; set; }
    }
}
