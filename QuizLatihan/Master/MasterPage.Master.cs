using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        public Button Loginbutton => LoginBtn;
        public Button Logoutbutton => LogoutBtn;
        public Button RegisterButton => RegisterBtn;
        public Button CartButton => CartBtn;
        public Button ProfileButton => ProfileBtn;
        public Button HandleOrderButton => HandleOrderBtn;
        public Button MyOrdersButton => MyOrdersBtn;
        public Button ReportButton => ReportBtn;
        public Button AddJewelButton => AddJewelBtn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string role = Session["role"] as string;

                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
                CartBtn.Visible = false;
                MyOrdersBtn.Visible = false;
                ProfileBtn.Visible = false;
                LogoutBtn.Visible = false;
                AddJewelBtn.Visible = false;
                ReportBtn.Visible = false;
                HandleOrderBtn.Visible = false;

                HomeBtn.Visible = true;

                if (role == null)
                {
                    //for guest
                    LoginBtn.Visible = true;
                    RegisterBtn.Visible = true;
                }
                else if (role == "Customer")
                {
                    CartBtn.Visible = true;
                    MyOrdersBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                else if (role == "Admin")
                {
                    AddJewelBtn.Visible = true;
                    ReportBtn.Visible = true;
                    HandleOrderBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
            }
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                GreetingLabel.Text = "Welcome, " + user.UserName;
            }
            else
            {
                GreetingLabel.Text = "";
            }

        }


        protected void HomeBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Homepage.aspx");
        }

        protected void LoginBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }

        protected void CartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CartPage.aspx");
        }

        protected void MyOrdersBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MyOrders.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/profilePage.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();
            Session.Abandon();

            // Hapus session cookie ASP.NET
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
            }

            if (Request.Cookies["UserEmail"] != null)
            {
                Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.Cookies["UserPassword"] != null)
            {
                Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("~/Views/Login.aspx");
        }

        protected void AddJewelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CreateJewel.aspx");
        }

        protected void ReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Report.aspx");
        }

        protected void HandleOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HandleOrder.aspx");
        }
    }
}