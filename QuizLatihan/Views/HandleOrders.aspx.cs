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
            if (status == "Payment Pending") return "Confirm Payment";
            if (status == "Shipment Pending") return "Ship Package";
            if (status == "Arrived") return "Waiting for user confirmation...";
            return "";
        }

        protected string GetActionCommand(string status)
        {
            if (status == "Payment Pending") return "ConfirmPayment";
            if (status == "Shipment Pending") return "ShipPackage";
            return "";
        }

        protected bool ShowActionButton(string status)
        {
            return status == "Payment Pending" || status == "Shipment Pending";
        }
    }
}