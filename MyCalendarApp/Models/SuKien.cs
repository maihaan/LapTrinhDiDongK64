using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCalendarApp.Models
{
    public class SuKien
    {
        public String ID { get; set; }
        public String Ma { get; set; }
        public String Ten { get; set; }
        public String DiaDiem { get; set; }
        public DateTime ThoiGian { get; set; }
        public int NhacTruoc { get; set; }
        public String Username { get; set; }
    }
}