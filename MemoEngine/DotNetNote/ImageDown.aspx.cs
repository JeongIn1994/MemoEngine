using System;
using System.IO;

namespace MemoEngine.DotNetNote
{
    public partial class ImageDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["FileName"]))
            {
                Response.End();
            }

            string fileName = Request.Params["FileName"].ToString();
            string ext = Path.GetExtension(fileName);
            string contentType = "";

            if(ext == ".gif" || ext == ".jpg" || ext == ".jpeg" || ext == ".png")
            {
                switch(ext)
                {
                    case ".gif":
                        contentType = "image/gif"; break;
                    case ".jpg":
                        contentType = "image/jpeg"; break;
                    case "jpeg":
                        contentType = "image/jpeg"; break;
                    case ".png":
                        contentType = "image/png"; break;
                }
            }
            else
            {
                Response.Write(
                    "<script language='javascript'>"
                    + "alert('이미지 파일이 아닙니다.')</script>");
                Response.End();
            }
            string file = Server.MapPath("./MyFiles/") + fileName;

            Response.Clear();
            Response.ContentType = contentType;
            Response.WriteFile(file);
            Response.End();
        }
    }
}