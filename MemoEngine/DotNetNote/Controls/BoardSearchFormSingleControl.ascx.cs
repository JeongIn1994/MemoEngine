using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.DotNetNote.Controls
{
    public partial class BoardSearchFormSingleControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strQuery =
                string.Format(
                    "/DotNetNote/BoardList.aspx?SearchField={0}&SearchQuery={1}", SearchField.SelectedItem.Value, SearchQuery.Text);
            Response.Redirect(strQuery);
        }
    }
}