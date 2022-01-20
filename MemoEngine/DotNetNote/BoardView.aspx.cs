using System;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote
{
    public partial class BoardView : System.Web.UI.Page
    {
        public string _Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDelete.NavigateUrl = "BoardDelete.aspx?Id=" + Request["Id"];
            lnkModify.NavigateUrl = "BoardModify.aspx?Id=" + Request["Id"];
            lnkReply.NavigateUrl = "BoardReply.aspx?Id=" + Request["Id"];

            _Id = Request.QueryString["Id"];
            if(_Id == null)
            {
                Response.Redirect("./BoardList.aspx");
            }

            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            var note = (new NoteRepository()).GetNoteById(Convert.ToInt32(_Id));

            lblNum.Text = _Id;
            lblName.Text = note.Name;
            lblEmail.Text = String.Format("<a href=\"mailto:{0}\">{0}</a>", note.Email);
            lblTitle.Text = note.Title;
            string content = note.Content;

            string strEncoding = note.Encoding;
            if(strEncoding == "Text")
            {
                lblContent.Text = Dul.HtmlUtility.EncodeWithTabAndSpace(content);
            }
            else if(strEncoding == "Mixed")
            {
                lblContent.Text = content.Replace("\r\n", "<br />");
            }
            else
            {
                lblContent.Text = content;
            }

            lblReadCount.Text = note.ReadCount.ToString();
            lblHomepage.Text = string.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", note.Homepage);
            lblPostDate.Text = note.PostDate.ToString();
            lblPostIp.Text = note.PostIp;
            if(note.FileName.Length > 1)
            {
                lblFile.Text = string.Format("<a href='.BoardDown.aspx?Id={0}'>"
                    + "{1}{2} /전송수 : {3}</a>", note.Id, "<img src=\"images/ext/ext_zip.gif\" border=\"0\">", note.FileName, note.DownCount);
                if (Dul.BoardLibrary.IsPhoto(note.FileName))
                {
                    ltrImage.Text = "<img src=\'ImageDown.aspx?FileName="
                        + $"{Server.UrlEncode(note.FileName)}\'>";
                }
            }
            else
            {
                lblFile.Text = "(업로드된 파일이 없습니다.)";
            }
        }
    }
}