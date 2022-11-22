using PrjWen.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrjWen.ViewModel
{
    public class credit
    {
        private CreditCard信用卡 _CreditCard;
        public CreditCard信用卡 CreditCard
        {
            get { return _CreditCard; }
            set { _CreditCard = value; }
        }
        public credit()
        {
            _CreditCard = new CreditCard信用卡();
        }
        [DisplayName("編號")]
        public int Cid信用卡流水號 
        { 
            get { return _CreditCard.Cid信用卡流水號; } 
            set { _CreditCard.Cid信用卡流水號 = value; } 
        }
        public bool? Cuse使用狀態 
        {
            get { return _CreditCard.Cuse使用狀態; }
            set { _CreditCard.Cuse使用狀態 = value; } 
        }
        [DisplayName("信用卡公司名稱")]
        public string Cname信用卡公司名 
        {
            get { return _CreditCard.Cname信用卡公司名; }
            set { _CreditCard.Cname信用卡公司名 = value; }
        }
        [DisplayName("信用卡卡號")]
        public string Cnum信用卡號 
        {
            get { return _CreditCard.Cnum信用卡號; }
            set { _CreditCard.Cnum信用卡號 = value; } 
        }
        public virtual ICollection<Member會員> Member會員s { get; set; }
    }
}