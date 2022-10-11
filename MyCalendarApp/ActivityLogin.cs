using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyCalendarApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MyCalendarApp
{
    [Activity(Label = "ActivityLogin", MainLauncher =true)]
    public class ActivityLogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            var btDangNhap = (Button)FindViewById(Resource.Id.btDangNhap);
            var tvQuenMatKhau = (TextView)FindViewById(Resource.Id.tvQuenMatKhau);

            btDangNhap.Click += BtDangNhap_Click;
            tvQuenMatKhau.Click += TvQuenMatKhau_Click;
        }

        private void TvQuenMatKhau_Click(object sender, EventArgs e)
        {
            
        }

        private void BtDangNhap_Click(object sender, EventArgs e)
        {
            // Lay ve cac thanh phan giao dien
            var etTenDangNhap = (EditText)FindViewById(Resource.Id.etTenDangNhap);
            var etMatKhau = (EditText)FindViewById(Resource.Id.etMatKhau);

            // Kiem soat du lieu dau vao
            if(String.IsNullOrEmpty(etTenDangNhap.Text))
            {
                Toast.MakeText(this, "Bạn phải nhập tên đăng nhập", ToastLength.Long).Show();                
                return;
            }


            if (String.IsNullOrEmpty(etMatKhau.Text))
            {
                Toast.MakeText(this, "Bạn phải nhập mật khẩu đăng nhập", ToastLength.Long).Show();
                return;
            }

            // Dang nhap
            String apiUrl = "http://172.20.10.8:7600/api/nguoidung/login?username=" + etTenDangNhap.Text.Trim()
                + "&password=" + etMatKhau.Text.Trim();

            WebClient c = new WebClient();
            c.DownloadStringCompleted += C_DownloadStringCompleted;            
            Uri uri = new Uri(apiUrl);
            c.DownloadStringAsync(uri);               
        }

        private void C_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var kq = e.Result;
            if (kq != null && kq.Length > 0)
            {
                String ketQua = kq;
                var nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(ketQua);
                if (nguoiDung != null)
                {
                    // Dang nhap thanh cong
                    Toast.MakeText(this, "Đăng nhập thành công!", ToastLength.Long).Show();
                }
                else
                {
                    // Dang nhap khong thanh cong
                    Toast.MakeText(this, "Đăng nhập thất bại!", ToastLength.Long).Show();
                }
            }
        }

        private void C_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            var kq = e.Result;
            if(kq  != null && kq.Length > 0)
            {
                String ketQua = Encoding.UTF8.GetString(kq);
                var nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(ketQua);
                if (nguoiDung != null)
                {
                    // Dang nhap thanh cong
                    Toast.MakeText(this, "Đăng nhập thành công!", ToastLength.Long).Show();
                }
                else
                {
                    // Dang nhap khong thanh cong
                    Toast.MakeText(this, "Đăng nhập thất bại!", ToastLength.Long).Show();
                }
            }    
        }
    }
}