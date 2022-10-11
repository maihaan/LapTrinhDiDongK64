using MyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCalendar.Controllers
{
    public class NguoiDungController : ApiController
    {
        [HttpGet]
        public NguoiDung Get(String username)
        {
            CNguoiDung c = new CNguoiDung();
            return c.GetByUsername(username);
        }


        [HttpGet]
        public List<NguoiDung> Get()
        {
            CNguoiDung c = new CNguoiDung();
            return c.DanhSach1("");
        }

        [Route("[action]")]
        [HttpGet]
        public List<NguoiDung> DanhSach(String dieuKien)
        {
            CNguoiDung c = new CNguoiDung();
            List<NguoiDung> ds = c.DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
            {
                return ds;
            }
            return null;
        }


        [Route("[action]")]
        [HttpGet]
        public NguoiDung Login(String username, String password)
        {
            CNguoiDung c = new CNguoiDung();
            NguoiDung nd = c.GetByUsername(username);
            if(nd != null)
            {
                if (nd.Password.Equals(password))
                    return nd;
            }
            return null;
        }

        [Route("[action]")]
        [HttpGet]
        public String Insert(String username, String password, String email)
        {
            CNguoiDung c = new CNguoiDung();
            if (c.Exist(username, email) != null)
            {
                return "Đã tồn tại";
            }
            else
            {
                NguoiDung nd = new NguoiDung();
                nd.Username = username;
                nd.Password = password;
                nd.Email = email;
                int dem = c.ThemMoi(nd);
                if (dem > 0)
                    return "Thành công";
                else
                    return "Lỗi";
            }
        }

        [Route("[action]")]
        [HttpGet]
        public String Update(String id, String username, String password, String email)
        {
            CNguoiDung c = new CNguoiDung();
            NguoiDung nd = new NguoiDung();
            nd.Username = username;
            nd.Password = password;
            nd.Email = email;
            nd.ID = id;
            int dem = c.CapNhat(nd);
            if (dem > 0)
                return "Thành công";
            else
                return "Lỗi";
        }


        [Route("[action]")]
        [HttpGet]
        public String Delete(String id)
        {
            CNguoiDung c = new CNguoiDung();
            NguoiDung nd = c.GetByID(id);
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