using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Handler;
using QuizLatihan.Repository;
using TransactionHandler = QuizLatihan.Handler.TransactionHandler;


namespace QuizLatihan.Views
{
    public partial class myOrders : System.Web.UI.Page
    {
        private TransactionHandler handler = new TransactionHandler(new TransactionRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("");
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            int userId = Session["userID"] != null ? Convert.ToInt32(Session["userID"]) : 0;
            if (userId == 0)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            var orders = handler.GetOrdersByUser(userId);

            if (orders == null || orders.Count == 0)
            {
                lblMessage.Text = "Tidak ada data transaksi untuk user " + userId;
                gvOrders.DataSource = null;
                gvOrders.DataBind();
            }
            else
            {
                lblMessage.Text = $"Jumlah transaksi: {orders.Count}";
                gvOrders.DataSource = orders;
                gvOrders.DataBind();
            }
            lblMessage.Text = "Tidak ada data transaksi untuk user " + userId;
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                PlaceHolder phActions = (PlaceHolder)e.Row.FindControl("phActions");

                phActions.Visible = (status == "Arrived");
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm" || e.CommandName == "Reject")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                string newStatus = e.CommandName == "Confirm" ? "Done" : "Rejected";

                handler.UpdateTransactionStatus(transactionId, newStatus);
                LoadOrders();
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}
