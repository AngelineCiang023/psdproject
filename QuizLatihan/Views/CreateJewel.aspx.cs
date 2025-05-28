using QuizLatihan.Controller;
using QuizLatihan.Handler;
using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
	public partial class CreateJewel : System.Web.UI.Page
	{
        private JewelController jewelController = new JewelController();
        private BrandHandler brandHandler = new BrandHandler();
        private CategoryHandler categoryHandler = new CategoryHandler();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                LoadDropdownBrand();
                LoadDropdownCategory();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = TxtJewelName.Text.Trim();
            string categoryId = DropDownCategory.SelectedValue;
            string brandId = DropDownBrand.SelectedValue;
            string price = TxtJewelPrice.Text.Trim();
            string releaseYear = TxtReleaseYear.Text.Trim();

            string error = jewelController.AddJewel(name, categoryId, brandId, price, releaseYear);

            if (!string.IsNullOrEmpty(error))
            {
                LblErrorMessage.Text = error;
            }
            else
            {
                Response.Redirect("HomePage.aspx");
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
    }
}