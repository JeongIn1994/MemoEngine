using System;
using System.Drawing;

namespace MemoEngine.DotNetNote
{
    public partial class ImageText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap = new Bitmap(80, 20);
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Random random = new Random();
            char c1 = (char)random.Next(65, 90);
            char c2 = (char)random.Next(48, 57);
            char c3 = (char)random.Next(97, 122);
            char c4 = (char)random.Next(48, 57);

            Session["ImageText"] = $"{c1}{c2}{c3}{c4}";

            objGraphics.DrawString(c1.ToString(), new Font("Verdana", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(5, 1));
            objGraphics.DrawString(c2.ToString(), new Font("Arial", 11, FontStyle.Italic), Brushes.DarkBlue, new Point(25, 1));
            objGraphics.DrawString(c3.ToString(), new Font("Verdana", 11, FontStyle.Regular), Brushes.DarkBlue, new Point(45, 1));
            objGraphics.DrawString(c4.ToString(), new Font("Arial", 12, FontStyle.Underline), Brushes.DarkBlue, new Point(65, 1));

            Response.ContentType = "image/gif";
            objBitmap.Save(
                Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);

            objBitmap.Dispose();
            objGraphics.Dispose();

        }
    }
}