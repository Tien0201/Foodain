using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WjbuGangVer2_WebNC.Models
{
    public class DetailsVM
    {
        public MatHang MatHangs_items { get; set; }
        public List<Comment> Comments_items { get; set; }
    }
}