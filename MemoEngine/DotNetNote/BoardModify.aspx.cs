using System;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote
{
    public partial class BoardModfiy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Modify;
        }
    }
}