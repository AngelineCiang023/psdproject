using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        LocalDatabaseEntities2 db = new LocalDatabaseEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Session["user"] as MsUser;

                // debug
                if (user == null)
                {
                    lblMessage1.Text = "Session kosong, redirect ke Login.aspx";
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }
                else
                {
                    lblWelcome1.Text = $"Welcome, {user.UserName}";
                }
            }
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as MsUser;
            if(user == null)
            {
                lblMessage1.Text = "Session expired. Please login again.";
                return;
            }

            string oldPassword = txtOldPassword1.Text.Trim();   
            string newPassword = txtNewPassword.Text.Trim();   
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (oldPassword != user.UserPassword)
            {
                lblMessage1.Text = "Old password is incorrect.";
                return;
            }

            if (newPassword.Length < 8 || newPassword.Length > 25 || !newPassword.All(char.IsLetterOrDigit))
            {
                lblMessage1.Text = "New password must be 8-25 characters and alphanumeric.";
                return;
            }

            if(newPassword != confirmPassword)
            {
                lblMessage1.Text = "Confirm password doesn't match.";
                return;
            }

            var dbUser = db.MsUsers.FirstOrDefault(u => u.UserID == user.UserID);
            dbUser.UserPassword = newPassword;
            db.SaveChanges();

            Session["user"] = dbUser;
            lblMessage1.ForeColor = System.Drawing.Color.Green;
            lblMessage1.Text = "Password changed successfully.";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}