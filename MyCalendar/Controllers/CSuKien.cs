using MyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyCalendar.Controllers
{
    public class CSuKien
    {
        DataAccess da = new DataAccess();
        public DataTable DanhSach(String dieuKien)
        {
            String query = "Select * From tbSuKien";
            if (!String.IsNullOrEmpty(dieuKien))
                query += " Where " + dieuKien;
            return da.Doc(query);
        }

        public List<SuKien> DanhSach1(String dieuKien)
        {
            DataTable tb = DanhSach(dieuKien);
            if(tb != null && tb.Rows.Count > 0)
            {
                List<SuKien> ds = new List<SuKien>();
                foreach(DataRow r in tb.Rows)
                {
                    SuKien m = new SuKien();
                    m.Username = r["Username"].ToString();
                    m.Ma = r["Ma"].ToString();
                    m.DiaDiem = r["DiaDiem"].ToString();
                    m.Ten = r["Ten"].ToString();
                    m.ThoiGian = DateTime.Parse(r["ThoiGian"].ToString());
                    m.NhacTruoc = int.Parse(r["NhacTruoc"].ToString());
                    m.ID = r["ID"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            return null;
        }

        public SuKien GetByMa(String ma)
        {
            String dieuKien = "Ma=N'" + ma + "'";
            List<SuKien> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public SuKien GetByID(String id)
        {
            String dieuKien = "id=" + id;
            List<SuKien> ds = DanhSach1(dieuKien);
            if (ds != null && ds.Count > 0)
                return ds[0];
            return null;
        }

        public List<SuKien> GetListByUser(String username, String dieuKien)
        {
            String dk = "Username = N'" + username + "'";
            if (!String.IsNullOrEmpty(dieuKien))
                dk += " And " + dieuKien;
            return DanhSach1(dk);
        }

        public int ThemMoi(SuKien m)
        {
            String query = "Insert into tbSuKien(Username, Ma, Ten, ThoiGian, NhacTruoc, DiaDiem) Values(N'"
                + m.Username + "',N'"
                + m.Ma + "',N'"
                + m.Ten + "', N'"
                + m.ThoiGian.ToString() + "',"
                + m.NhacTruoc.ToString() + ",N'"
                + m.DiaDiem + "')";
            return da.Ghi(query);
        }

        public int CapNhat(SuKien m)
        {
            String query = "Update tbSuKien Set Username=N'"
                + m.Username + "',Ten=N'"
                + m.Ten + "', ThoiGian= N'"
                + m.ThoiGian.ToString() + "', NhacTruoc="
                + m.NhacTruoc.ToString() + ",Ma = N'"
                + m.Ma + "',DiaDiem=N'"
                + m.DiaDiem + "' Where ID=" + m.ID;
            return da.Ghi(query);
        }

        public int Xoa(String id)
        {
            String query = "Delete tbSuKien Where ID=" + id;
            return da.Ghi(query);
        }

        public int XoaNhieu(String dieuKien)
        {
            String query = "Delete tbSuKien";
            if (!String.IsNullOrEmpty(dieuKien))
            {
                query += " Where " + dieuKien;
                return da.Ghi(query);
            }
            else
                return -2;
        }
    }
}