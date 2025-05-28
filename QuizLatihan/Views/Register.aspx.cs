using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Views
{
    public partial class Register : System.Web.UI.Page
    {
        LocalDatabaseEntities2 db = new LocalDatabaseEntities2 ();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Btn_Click(object sender, EventArgs e)
        {
            string Email = Email_Tb.Text.Trim();
            string Username = Username_Tb.Text.Trim();
            string Password = Password_Tb.Text;
            string confirmPassword = ConfirmPassword_Tb.Text;
            string Gender = Gender_Rbl.SelectedValue;
            DateTime dob;

            List<string> list = new List<string> ();
            if (string.IsNullOrEmpty(Email) || !Email.Contains("@") || !Email.Contains("."))
            {
                list.Add("Email must be a valid format.");
            }
            else if (db.MsUsers.Any(u => u.UserEmail == Email))
            {
                list.Add("Email already registered.");
            }

            // Validasi Username
            if (Username.Length < 3 || Username.Length > 25)
            {
                list.Add("Username must be between 3 and 25 characters.");
            }

            // Validasi Password
            if (Password.Length < 8 || Password.Length > 20 || !Password.All(char.IsLetterOrDigit))
            {
                list.Add("Password must be alphanumeric and between 8-20 characters.");
            }

            // Validasi Confirm Password
            if (Password != confirmPassword)
            {
                list.Add("Password and Confirm Password do not match.");
            }

            // Validasi Gender
            if (Gender != "Male" && Gender != "Female")
            {
                list.Add("Gender must be chosen.");
            }

            // Validasi Date of Birth
            if (!DateTime.TryParse(BirthDate_Tb.Text, out dob))
            {
                list.Add("Please enter a valid date of birth.");
            }
            else if (dob >= new DateTime(2010, 1, 1))
            {
                list.Add("Date of birth must be earlier than 01/01/2010.");
            }

            // Jika ada error, tampilkan semua
            if (list.Count > 0)
            {
                Validasi.Text = string.Join("<br/>", list);
                return;
            }
            else
            {
                Validasi.Text = "You successfull";
                MsUser user = new MsUser(); 
                user.UserName = Username;
                user.UserPassword = Password; 
                user.UserGender = Gender;
                user.UserEmail = Email_Tb.Text;
                user.UserDOB = dob;
                user.UserRole = "Customer";

                try
                {
                    db.MsUsers.Add(user);
                    db.SaveChanges();
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    Validasi.Text = "Error occurred: " + ex.Message;
                }
            }
        }

        protected void Login_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}