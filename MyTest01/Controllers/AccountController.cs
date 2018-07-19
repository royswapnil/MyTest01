using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ActiveBusinessEdi.Controllers
{
    public class AccountController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyId = "_Id";
        const string SessionKeyPwd = "_Pwd";
        public static string connetionString = "Server=sl-us-south-1-portal.19.dblayer.com;port=34034;database=aipandl_2010;uid=admin;pwd=TNJKDNNLFAMYDLBL;SslMode=Required;";
        // GET: /<controller>/
        public IActionResult Login()
        {
            ViewData["UserName"] = "";
            ViewData["Message"] = "";
            HttpContext.Session.SetString(SessionKeyName, "");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string txtUserName, string txtPassword)
        {
            try
            {
                string pwd = PasswordHash(txtPassword);
                ViewData["UserName"] = "";
                ViewData["Message"] = "";
                string command = "select UserID, UserName, Password from ActiveUser where UserName='" + txtUserName + "' and Password = '" + pwd + "' and Status=1";
                using (MySqlConnection connection = new MySqlConnection(connetionString))
                {
                    connection.Open();
                    MySqlCommand sqlCmd = new MySqlCommand(command, connection);
                    var dr = sqlCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        HttpContext.Session.SetString(SessionKeyId, dr.GetString("UserID"));
                        HttpContext.Session.SetString(SessionKeyName, txtUserName);
                        HttpContext.Session.SetString(SessionKeyPwd, txtPassword);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            ViewData["Message"] = "Incorrect User Id or Password";
            return View();
        }

        public IActionResult ChangePassword()
        {
            try
            {
                if (HttpContext.Session.GetString("_Name") == null || HttpContext.Session.GetString("_Name") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewData["UserName"] = HttpContext.Session.GetString("_Name").Trim();
                ViewData["OldPwd"] = HttpContext.Session.GetString(SessionKeyPwd);
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public JsonResult ChangePass(string OldPwd, string NewPwd, string ConPwd)
        {
            try
            {
                string id = HttpContext.Session.GetString(SessionKeyId);
                string pwd = PasswordHash(NewPwd);
                string command = "update ActiveUser set Password='" + pwd + "' where UserID='" + id + "';";
                UpdateData(command);
                return Json("success");
            }
            catch (Exception e)
            {
                return Json("fail" +e.ToString());
            }
        }

        public static void UpdateData(string sqlcommand)
        {
            //string connetionString = "Server=sl-us-south-1-portal.19.dblayer.com;port=34034;database=aipandl_2010;uid=admin;pwd=TNJKDNNLFAMYDLBL;SslMode=Required;";
            using (MySqlConnection connection = new MySqlConnection(connetionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(sqlcommand, connection);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
            }
        }

        public string PasswordHash(string password)
        {
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashData)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

    }
}