using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WjbuGangVer2_WebNC.Models
{
    public class CommentViewModel
    {
        public int CmtID { get; set; }
        public int MaMH { get; set; }
        public string HoTen { get; set; }
        public int AccountID { get; set; }
        public string CmtMsg { get; set; }
        public Nullable<System.DateTime> CmtDate { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> DanhGia { get; set; }

        //public virtual account account { get; set; }
        //public virtual mathang mathang { get; set; }
    }
}