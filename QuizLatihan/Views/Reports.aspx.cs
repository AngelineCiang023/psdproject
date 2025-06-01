using QuizLatihan.Handler;
using QuizLatihan.Repository;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizLatihan.Views
{
    public partial class Reports : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var handler = new ReportHandler(new TransactionRepository());
                var reportData = handler.GetDoneTransactions();

                GridViewReport.DataSource = reportData;
                GridViewReport.DataBind();
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TransactionReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridViewReport.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}
