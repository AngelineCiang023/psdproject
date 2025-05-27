using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            Response.Redirect("~/Cart.aspx");
        }

        protected void MyOrdersBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyOrders.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogOut.aspx");
        }

        protected void AddJewelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddJewel.aspx");
        }

        protected void ReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Report.aspx");
        }

        protected void HandleOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HandleOrder.aspx");
        }
    }
}