using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC追加機能.Models
{
    public class ApplicationInfoRowModel
    {
        public string 状態 { get; set; }
        public string 申請ID { get; set; }
        public string 申請種類 { get; set; }//検索結果の状態を表す
        public string タイトル { get; set; }
        public string 申請日 { get; set; }
        public string 承認日 { get; set; }
        public string 連絡事項 { get; set; }
        
        
        
    }
}