using System;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote
{
    public partial class BoardDown : System.Web.UI.Page
    {
        private string fileName = "";
        private string dir = "";

        private NoteRepository _repository;
        public BoardDown()
        {
            _repository = new NoteRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            fileName = _repository.GetFileNameById(Convert.ToInt32(Request["Id"]));

            dir = Server.MapPath("./MyFiles/");
            if(fileName == null)
            {
                Response.Clear();
                Response.End();
            }
            else
            {

                _repository.UpdateDownCount(fileName);

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename="
                    + Server.UrlPathEncode(
                        (fileName.Length > 50) ?
                        fileName.Substring(fileName.Length - 50, 50) : fileName));

                Response.Write(dir + fileName);
                Response.End();
            }   
        }
    }
}