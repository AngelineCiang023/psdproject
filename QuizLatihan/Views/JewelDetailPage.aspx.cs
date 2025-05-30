using QuizLatihan.Controller;
using QuizLatihan.Handler;
using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
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
            int jewelId =int.Parse(Request.QueryString["id"]);
            jewelController.DeleteJewel(jewelId);
            Response.Redirect("Homepage.aspx");
        }

        protected void Btn_AddToCart_Click(object sender, EventArgs e)
        {

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