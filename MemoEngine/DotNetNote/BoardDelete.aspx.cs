using System;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote
{
    public partial class BoardDelete : System.Web.UI.Page
    {
        private string _Id;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request.QueryString["Id"];
            lnkCancel.NavigateUrl = "BoardView.aspx?Id=" + _Id;
            lblId.Text = _Id;

            btnDelete.Attributes["onclick"] = "return ConfirmDelete();";

            if (string.IsNullOrEmpty(_Id))
            {
                Response.Redirect("BoardList.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if((new NoteRepository()).DeleteNote(
                Convert.ToInt32(_Id), txtPassword.Text) > 0)
            {
                Response.Redirect("BoardList.aspx");
            }
            else
            {
                lblMessage.Text = "삭제되지 않았습니다. 비밀번호를 확인하세요.";
            }
        }
    }
}