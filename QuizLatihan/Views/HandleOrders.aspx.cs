using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null)
            {
                Session["UserRole"] = "Admin";
            }

            if (Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        // Sementara data kosong, nanti bisa diganti dengan data dari DB
        private void BindGrid()
        {
            List<object> emptyList = new List<object>();
            UnfinishedTransactionGridView.DataSource = emptyList;
            UnfinishedTransactionGridView.DataBind();
        }

        protected void UnfinishedTransactionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Tidak ada data, jadi event ini bisa kosong dulu
            }
        }

        protected void ConfirmPaymentBtn_Click(object sender, EventArgs e)
        {
            // Nanti bisa diisi dengan update status di DB
        }

        protected void ShipPackageBtn_Click(object sender, EventArgs e)
        {
            // Nanti bisa diisi dengan update status di DB
        }
    }
}
