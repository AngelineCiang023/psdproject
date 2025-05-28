using QuizLatihan.Controller;
using QuizLatihan.Handler;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
	public partial class UpdateJewel : System.Web.UI.Page
	{
        private JewelController jewelController = new JewelController();
        private BrandHandler brandHandler = new BrandHandler();
        private CategoryHandler categoryHandler = new CategoryHandler();

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int jewelId = int.Parse(Request.QueryString["id"]);
                    LoadDropdownBrand();
                    LoadDropdownCategory();
                    LoadJewelData(jewelId);
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        public void LoadDropdownBrand()
        {
            var brands = brandHandler.GetBrands();
            DropDownBrand.DataSource = brands;
            DropDownBrand.DataTextField = "BrandName";
            DropDownBrand.DataValueField = "BrandId";
            DropDownBrand.DataBind();
        }

        public void LoadDropdownCategory()
        {
            var categories = categoryHandler.GetCategory();

            DropDownCategory.DataSource = categories;
            DropDownCategory.DataTextField = "CategoryName";
            DropDownCategory.DataValueField = "CategoryId";
            DropDownCategory.DataBind();
        }

        private void LoadJewelData(int jewelId)
        {
            var jewel = jewelController.GetJewelById(jewelId);
            if (jewel != null)
            {
                TxtJewelName.Text = jewel.JewelName;
                TxtPrice.Text = jewel.JewelPrice.ToString();
                TxtReleaseYear.Text = jewel.JewelReleaseYear.ToString();
                DropDownCategory.SelectedValue = jewel.CategoryID.ToString();
                DropDownBrand.SelectedValue = jewel.BrandID.ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["id"]); // Ambil ID dari query string

            // Ambil input dari form
            string name = TxtJewelName.Text.Trim();
            string categoryId = DropDownCategory.SelectedValue;
            string brandId = DropDownBrand.SelectedValue;
            string price = TxtPrice.Text.Trim();
            string releaseYear = TxtReleaseYear.Text.Trim();

            // Panggil controller untuk update data
            string error = jewelController.UpdateJewel(jewelId, name, categoryId, brandId, price, releaseYear);

            if (!string.IsNullOrEmpty(error))
            {
                LblErrorMessage.Text = error;
            }
            else
            {
                // Jika sukses, redirect ke homepage atau detail page
                Response.Redirect("HomePage.aspx");
            }
        }

    }
}