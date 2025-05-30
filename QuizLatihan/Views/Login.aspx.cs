using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Views
{
	public partial class Login : System.Web.UI.Page
	{
		LocalDatabaseEntities2 db = new LocalDatabaseEntities2();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				if (Request.Cookies["UserEmail"] != null && Request.Cookies["UserPassword"] != null)
				{
					string Email = Request.Cookies["UserEmail"].Value;
					string Password = Request.Cookies["UserPassword"].Value;

					var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == Email && u.UserPassword == Password);
					if (user != null)
					{
						Session["user"] = user;
                        Session["UserRole"] = user.UserRole;
                        Response.Redirect("HomePage.aspx");
					}
				}
			}
		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
			string Email = txtEmail.Text.Trim();
			string Password = txtPassword.Text.Trim();

			if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
			{
				lblError.Text = "Email and Password must be filled.";
				return; 
			}

			var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == Email);
			if(user == null)
			{
				lblError.Text = "Email is not registered, please Register!";
				return;
			}

			if(user.UserPassword != Password)
			{
				lblError.Text = "incorrect password";
				return;
			}

			//login berhasil
			Session["user"] = user;
			Session["UserRole"] = user.UserRole;

			//jika rememberme dicentang, cookie disimpan otomatis
			if (chkRemember.Checked)
			{
				HttpCookie emailCookie = new HttpCookie("UserEmail", Email);
				HttpCookie passCookie = new HttpCookie("UserPassword", Password);

				emailCookie.Expires = DateTime.Now.AddDays(7);
				passCookie.Expires = DateTime.Now.AddDays(7);

				Response.Cookies.Add(emailCookie);
				Response.Cookies.Add(passCookie);
			}

			Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
			Response.Redirect("Register.aspx");
        }
    }
}