using QuizLatihan.Controller;
using QuizLatihan.Handler;
using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
	public partial class JewelDetailPage : System.Web.UI.Page
	{
        private JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int jewelId = int.Parse(Request.QueryString["id"]);
                LoadJewelDetails(jewelId);
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["id"]);
            Response.Redirect("UpdateJewel.aspx?id=" + jewelId);
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["id"]);
            jewelController.DeleteJewel(jewelId);
            Response.Redirect("HomePage.aspx");
        }

        protected void Btn_AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                // Pastikan user sudah login
                Response.Redirect("~/Views/Login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["userID"]);

            if (!int.TryParse(Request.QueryString["id"], out int jewelId))
            {
                lblMessage.Text = "Invalid jewel ID.";
                return;
            }

            using (LocalDatabaseEntities2 db = new LocalDatabaseEntities2())
            {
                var existingCart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                if (existingCart != null)
                {
                    existingCart.Quantity += 1;
                }
                else
                {
                    var cart = new Cart
                    {
                        UserID = userId,
                        JewelID = jewelId,
                        Quantity = 1
                    };
                    db.Carts.Add(cart);
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    var inner = ex.InnerException?.InnerException;
                    if (inner != null)
                        lblMessage.Text = "DB error: " + inner.Message;
                    else
                        lblMessage.Text = "DB error: " + ex.Message;
                    return; 
                }
            }
            Response.Redirect("~/Views/CartPage.aspx");
        }

        private void LoadJewelDetails(int jewelId)
        {
            MsJewel jewel = jewelController.GetJewelById(jewelId);
            if (jewel != null)
            {
                Lbl_JewelID.Text = "Jewel ID: " + jewel.JewelID;
                Lbl_JewelName.Text = "Jewel Name: " + jewel.JewelName;
                Lbl_JewelPrice.Text = "Jewel Price: $" + jewel.JewelPrice;
                Lbl_CategoryName.Text = "Category Name: " + jewel.MsCategory.CategoryName;
                Lbl_BrandName.Text = "Brand Name: " + jewel.MsBrand.BrandName;
                Lbl_BrandCountry.Text = "Brand Country: " + jewel.MsBrand.BrandCountry;
                Lbl_BrandClass.Text = "Brand Class: " + jewel.MsBrand.BrandClass;
                Lbl_ReleaseYear.Text = "Release Year: " + jewel.JewelReleaseYear;
            }
        }
    }
}