using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace FutureSoftWeb.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-NA6JOAP\SQLEXPRESS;Initial Catalog=dbFutureSoft;Integrated Security=True");
        // GET: Login
        public ActionResult _Login()
        {
            return View();
        }


        public ActionResult LoginFunc(string email, string password)
        {
                connect.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM tbl_Kullanici WHERE kAdi=@ka AND kSifre=@s", connect);
                komut.Parameters.AddWithValue("@ka", email);
                komut.Parameters.AddWithValue("@s", password);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    connect.Close();
                return RedirectToAction("Index", "Category");
                    
                }
                else
                {
                    connect.Close();
                return View("_Login");
                }
        }
    }
}