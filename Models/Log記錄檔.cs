using System;
using System.Collections.Generic;

#nullable disable

namespace PrjWen.Models
{
    public partial class Log記錄檔
    {
        public int Id { get; set; }
        public string SysController { get; set; }
        public string SysAction { get; set; }
        public DateTime? CreatedTime建立時間 { get; set; }
        public string Level級別 { get; set; }
        public string Message訊息 { get; set; }
        public string LoggerName登入者 { get; set; }
        public string System { get; set; }
        public string SessionId { get; set; }
    }
}
