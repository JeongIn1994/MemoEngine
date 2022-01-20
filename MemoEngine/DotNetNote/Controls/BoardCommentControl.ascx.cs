using System;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote.Controls
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private NoteCommentRepository _repository;
        public BoardCommentControl()
        {
            _repository = new NoteCommentRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlCommentList.DataSource = _repository.GetNoteComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind();
            }
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            NoteComment comment = new NoteComment();
            comment.BoardId = Convert.ToInt32(Request["Id"]);
            comment.Name = txtName.Text;
            comment.Password = txtPassword.Text;
            comment.Opinion = txtOpinion.Text;

            _repository.AddNoteComment(comment);

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");
        }
    }
}