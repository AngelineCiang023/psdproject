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
	public partial class JewelDetailPage : System.Web.UI.Page
	{
        JewelHandler jewelHandler = new JewelHandler();
        JewelRepository jewelRepository = new JewelRepository();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["id"] != null)
            {
                // Ambil ID dari query string
                int jewelId = int.Parse(Request.QueryString["id"]);

                // Panggil method GetJewelByIdWithDetails pada instance jewelRepository
                var jewel = jewelRepository.GetJewelByIdWithDetails(jewelId);

                if (jewel != null)
                {
                    // Tampilkan data jewel ke Label
                    Lbl_JewelID.Text = "JewelID: " + jewel.JewelID;
                    Lbl_JewelName.Text = "JewelName: " + jewel.JewelName;
                    Lbl_JewelPrice.Text = "JewelPrice: " + jewel.JewelPrice.ToString("C");
                    Lbl_CategoryName.Text = "CategoryName: " + jewel.MsCategory.CategoryName;
                    Lbl_BrandName.Text = "BrandName: " + jewel.MsBrand.BrandName;
                    Lbl_BrandCountry.Text = "BrandCountry: " + jewel.MsBrand.BrandCountry;
                }
                else
                {
                    // Jika jewel tidak ditemukan
                    Response.Write("<script>alert('Jewel tidak ditemukan!');</script>");
                }
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_AddToCart_Click(object sender, EventArgs e)
        {

        }
    }
}