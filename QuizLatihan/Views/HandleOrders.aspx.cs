using QuizLatihan.Handler;
using QuizLatihan.Repository;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        private TransactionHandler _handler;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Homepage.aspx");
                return;
            }
            try
            {
                _handler = new TransactionHandler(new TransactionRepository());

                if (!IsPostBack)
                {
                    BindTransactionData();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<p style='color:red;'>Page_Load ERROR: " + ex.Message + "</p>");
            }
        }

        private void BindTransactionData()
        {
            try
            {
                var data = _handler.GetUnfinishedTransactions();

                if (data == null || data.Count == 0)
                {
                    Response.Write("<p style='color:blue;'>Tidak ada transaksi yang perlu ditangani.</p>");
                }

                GridViewOrders.DataSource = data;
                GridViewOrders.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<p style='color:red;'>Error loading data: " + ex.Message + "</p>");
            }
        }

        protected void GridViewOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int transactionId = Convert.ToInt32(GridViewOrders.DataKeys[index].Value);

                if (e.CommandName == "ConfirmPayment")
                {
                    _handler.UpdateTransactionStatus(transactionId, "Shipment Pending");
                }
                else if (e.CommandName == "ShipPackage")
                {
                    _handler.UpdateTransactionStatus(transactionId, "Arrived");
                }
                else if (e.CommandName == "Reject")
                {
                    _handler.UpdateTransactionStatus(transactionId, "Rejected");
                }

                BindTransactionData();
            }
            catch (Exception ex)
            {
                Response.Write("<p style='color:red;'>Error updating transaction: " + ex.Message + "</p>");
            }
        }

        protected string GetActionText(string status)
        {
            switch (status.ToLower())
            {
                case "payment pending": return "Confirm Payment";
                case "shipment pending": return "Ship Package";
                case "arrived": return "Waiting for user confirmation...";
                default: return "";
            }
        }

        protected string GetActionCommand(string status)
        {
            switch (status.ToLower())
            {
                case "payment pending": return "ConfirmPayment";
                case "shipment pending": return "ShipPackage";
                default: return "";
            }
        }

        protected bool ShowActionButton(string status)
        {
            status = status.ToLower();
            return status == "payment pending" || status == "shipment pending";
        }
    }
}