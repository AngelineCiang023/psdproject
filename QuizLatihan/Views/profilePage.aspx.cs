using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Views
{
    public partial class profilePage : System.Web.UI.Page
    {
        LocalDatabaseEntities2 db = new LocalDatabaseEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
                {
                    if (Session["user"] == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }
                    var user = (MsUser)Session["user"];
                    LblWelcome.Text = $"Welcome, {user.UserName} ({user.UserEmail})";
                }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }

            var user = (MsUser)Session["user"];
            string oldPassword =txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if(user.UserPassword != oldPassword)
            {
                lblMessage.Text = "old password is incorrect";
                return;
            }

            if(newPassword.Length < 8 || newPassword.Length > 25 || !newPassword.All(char.IsLetterOrDigit))
            {
                lblMessage.Text = "new password must be 8-25 charactters and alphanumeric";
                return;
            }

            if(newPassword != confirmPassword)
            {
                lblMessage.Text = "Confirm password does not match new password.";
                return;
            }

            var currentUser = db.MsUsers.FirstOrDefault(u=> u.UserID == user.UserID);
            if(currentUser != null)
            {
                currentUser.UserPassword = newPassword;
                db.SaveChanges();

                Session["user"] = currentUser;

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Password successfully changed!";
            }
            else
            {
                lblMessage.Text = "Error occured while updating password.";
                }
          }

        protected void Btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Homepage.aspx");
        }
    }
}