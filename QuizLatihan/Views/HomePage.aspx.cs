using QuizLatihan.Handler;
using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
	public partial class HomePage : System.Web.UI.Page
	{

        private JewelHandler handler = new JewelHandler();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                var master = (QuizLatihan.Master.MasterPage)this.Master;
                master.AddJewelButton.Visible = false;
                master.ProfileButton.Visible = true;
                LoadData();
            }
        }

        public void LoadData()
        {
            List<MsJewel> jewels = handler.GetAllJewels();
            GridView1.DataSource = jewels;
            GridView1.DataBind();
        }

        protected void Btn_Details_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("JewelDetailPage.aspx?id=" + id);
        }
    }
}