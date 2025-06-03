using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizLatihan.Model;

namespace QuizLatihan.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadCart();
                LoadPaymentMethods();
            }
        }

        private void LoadCart()
        {
            if (Session["userID"] == null)
            {
                lblMessage.Text = "User not logged in.";
                return;
            }

            var user = Session["user"] as MsUser;
            if (user == null)
            {
                lblMessage.Text = "User not logged in.";
                return;
            }
            int userId = user.UserID;
            var cartItems = (from c in db.Carts
                             join j in db.MsJewels on c.JewelID equals j.JewelID
                             join b in db.MsBrands on j.BrandID equals b.BrandID
                             where c.UserID == userId
                             select new
                             {
                                 JewelID = (int?)j.JewelID,
                                 JewelName = j.JewelName,
                                 JewelPrice = (decimal?)j.JewelPrice ?? 0m,
                                 BrandName = b.BrandName,
                                 Quantity = (int?)c.Quantity ?? 0,
                                 Subtotal = ((int?)c.Quantity ?? 0) * ((decimal?)j.JewelPrice ?? 0m)
                             }).ToList();

            gvCart.DataSource = cartItems;
            gvCart.DataBind();

            decimal total = cartItems.Sum(x => x.Subtotal);
            lblTotal.Text = "Total: $" + total.ToString("N2");
        }

        private void LoadPaymentMethods()
        {
            ddlPayment.Items.Clear();
            ddlPayment.Items.Add("--Select--");
            ddlPayment.Items.Add("Visa");
            ddlPayment.Items.Add("MasterCard");
            ddlPayment.Items.Add("Paypal");
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCart.Rows[index];
            int jewelId = Convert.ToInt32(gvCart.DataKeys[index].Value);
            int userId = Convert.ToInt32(Session["userID"]);

            if (e.CommandName == "UpdateItem")
            {
                TextBox txtQty = (TextBox)row.FindControl("txtQuantity");
                if (int.TryParse(txtQty.Text, out int qty) && qty > 0)
                {
                    var cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                    if (cart != null)
                    {
                        cart.Quantity = qty;
                        db.SaveChanges();
                        LoadCart();
                    }
                }
            }
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            var cartItems = db.Carts.Where(c => c.UserID == userId);
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
            LoadCart();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (ddlPayment.SelectedIndex == 0)
            {
                lblMessage.Text = "Please select a payment method";
                return;
            }

            int userId = Convert.ToInt32(Session["userID"]);
            var cartItems = db.Carts.Where(c => c.UserID == userId);

            if (!cartItems.Any()) return;

            var header = new TransactionHeader
            {
                UserID = userId,
                TransactionDate = DateTime.Now.Date,
                PaymentMethod = ddlPayment.SelectedItem.Text,
                TransactionStatus = "payment pending"
            };

            db.TransactionHeaders.Add(header);
            db.SaveChanges();

            foreach (var item in cartItems)
            {
                var detail = new TransactionDetail
                {
                    TransactionID = header.TransactionID,
                    JewelID = item.JewelID,
                    Quantity = item.Quantity
                };
                db.TransactionDetails.Add(detail);
            }

            try
            {
                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
                Response.Redirect("MyOrders.aspx");
            }
            catch (DbUpdateException ex)
            {
                Exception inner = ex;
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }
                lblMessage.Text = "Checkout Error: " + inner.Message;
            }
        }

        protected Label LblMessage => (Label)FindControl("lblMessage");
        protected GridView GvCart => (GridView)FindControl("gvCart");
        protected Label LblTotal => (Label)FindControl("lblTotal");
        protected DropDownList DdlPayment => (DropDownList)FindControl("ddlPayment");

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}