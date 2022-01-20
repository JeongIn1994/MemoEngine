using MemoEngine.DotNetNote.Models;
using System;

namespace MemoEngine.DotNetNote
{
    public partial class BoardCommentDelete : System.Web.UI.Page
    {
        public int BoardId { get; set; }
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["BoardId"] != null && Request.QueryString["Id"] != null)
            {
                BoardId = Convert.ToInt32(Request["BoardId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e)
        {
            var repo = new NoteCommentRepository();
            if (repo.GetCountBy(BoardId, Id, txtPassword.Text) > 0)
            {
                repo.DeleteNoteComment(BoardId, Id, txtPassword.Text);
                Response.Redirect($"BoardView.aspx?Id={BoardId}");
            }
        }
    }
}