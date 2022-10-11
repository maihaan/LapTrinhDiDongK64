using MyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyCalendar.Controllers
{
    public class CNguoiDung
    {
        DataAccess da = new DataAccess();
        public DataTable DanhSach(String dieuKien)
        {
            String query = "Select * From tbNguoiDung";
            if (!String.IsNullOrEmpty(dieuKien))
                query += " Where " + dieuKien;
            return da.Doc(query);
        }

        public List<NguoiDung> DanhSach1(String dieuKien)
        {
            DataTable tb = DanhSach(dieuKien);
            if(tb != null && tb.Rows.Count > 0)
            {
                List<NguoiDung> ds = new List<NguoiDung>();
                foreach(DataRow r in tb.Rows)
                {
                    NguoiDung m = new NguoiDung();
                    m.Username = r["Username"].ToString();
                    m.Password = r["Password"].ToString();
                    m.Email = r["Email"].ToString();
                    m.ID = r["ID"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            return null;
        }

        public NguoiDung GetByUsername(String username)
        {
            String dieuKien = "Username=N'" + username + "'";
            List<NguoiDung> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public NguoiDung GetByID(String id)
        {
            String dieuKien = "ID=" + id;
            List<NguoiDung> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public NguoiDung Exist(String username, String email)
        {
            String dieuKien = "Username=N'" + username + "' Or Email=N'" + email + "'";
            List<NguoiDung> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public NguoiDung Exist(String username)
        {
            String dieuKien = "Username=N'" + username + "'";
            List<NguoiDung> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public int ThemMoi(NguoiDung m)
        {
            String query = "Insert into tbNguoiDung(Username, Password, Email) Values(N'"
                + m.Username + "',N'"
                + m.Password + "',N'"
                + m.Email + "')";
            return da.Ghi(query);
        }

        public int CapNhat(NguoiDung m)
        {
            String query = "Update tbNguoiDung Set Username=N'"
                + m.Username + "',Password=N'"
                + m.Password + "',Email=N'"
                + m.Email + "' Where ID=" + m.ID;
            return da.Ghi(query);
        }

        public int Xoa(String id)
        {
            String query = "Delete tbNguoiDung Where ID=" + id;
            return da.Ghi(query);
        }
    }
}