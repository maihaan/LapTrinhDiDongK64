using MyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCalendar.Controllers
{
    public class SuKienController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public SuKien Get(String ma)
        {
            CSuKien c = new CSuKien();
            return c.GetByMa(ma);
        }

        [Route("[action]")]
        [HttpGet]
        public String Insert(String ma, String ten, String thoiGian, String diaDiem, int nhacTruoc, String username)
        {
            CSuKien c = new CSuKien();
            SuKien sk = new SuKien();
            sk.Username = username;
            sk.Ma = ma;
            sk.Ten = ten;
            sk.ThoiGian = DateTime.Parse(thoiGian);
            sk.DiaDiem = diaDiem;
            sk.NhacTruoc = nhacTruoc;
            int dem = c.ThemMoi(sk);
            if (dem > 0)
                return "Thành công";
            else
                return "Lỗi";
        }

        [Route("[action]")]
        [HttpGet]
        public String Update(String ma, String ten, String thoiGian, String diaDiem, int nhacTruoc, String username)
        {
            CSuKien c = new CSuKien();
            SuKien sk = c.GetByMa(ma);
            if (sk != null)
            {
                sk.Username = username;
                sk.Ma = ma;
                sk.Ten = ten;
                sk.ThoiGian = DateTime.Parse(thoiGian);
                sk.DiaDiem = diaDiem;
                sk.NhacTruoc = nhacTruoc;
                int dem = c.CapNhat(sk);
                if (dem > 0)
                    return "Thành công";
                else
                    return "Lỗi";
            }
            else
            {
                return "Không tìm thấy";
            }
        }

        [Route("[action]")]
        [HttpGet]
        public String Delete(String id)
        {
            CSuKien c = new CSuKien();
            SuKien nd = c.GetByID(id);
            if (nd != null)
            {
                int dem = c.Xoa(id);
                if (dem > 0)
                    return "Thành công";
                else
                    return "Lỗi";
            }
            else
            {
                return "Không tìm thấy";
            }
        }
    }
}