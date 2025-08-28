using System;
using System.Linq;
using System.Web.UI;
using QuizLatihan.Repository;

namespace QuizLatihan.Views
{
    public partial class TransactionDetails : Page
    {
        private readonly ITransactionRepository _transactionRepository = new TransactionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TransactionID"] != null && int.TryParse(Request.QueryString["TransactionID"], out int transactionId))
                {
                    lblTransactionId.Text = $"Transaction ID: {transactionId}";
                    LoadTransactionDetails(transactionId);
                }
                else
                {
                    lblTransactionId.Text = "Invalid or missing Transaction ID.";
                }
            }
        }

        private void LoadTransactionDetails(int transactionId)
        {
            var transaction = _transactionRepository.GetTransactionById(transactionId);

            if (transaction != null && transaction.TransactionDetails.Any())
            {
                var details = transaction.TransactionDetails.Select(td => new
                {
                    TransactionID = transaction.TransactionID,
                    JewelName = td.MsJewel.JewelName,
                    Quantity = td.Quantity
                }).ToList();

                GridViewTransactionDetails.DataSource = details;
                GridViewTransactionDetails.DataBind();
            }
            else
            {
                // Kosongkan grid jika tidak ada data
                GridViewTransactionDetails.DataSource = null;
                GridViewTransactionDetails.DataBind();
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/myOrders.aspx");
        }
    }
}
