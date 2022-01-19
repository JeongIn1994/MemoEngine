using System;
using System.Web.UI;
using MemoEngine.DotNetNote.Models;

namespace MemoEngine.DotNetNote
{
    public partial class BoardList : System.Web.UI.Page
    {
        public bool SearchMode { get; set; }
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        public int PageIndex = 0;
        public int RecordCount = 0;
        private NoteRepository _repository;
        public BoardList()
        {
            _repository = new NoteRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchMode = (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !string.IsNullOrEmpty(Request.QueryString["SearchQuery"]));

            if (SearchMode)
            {
                SearchField = Request.QueryString["SearchField"];
                SearchQuery = Request.QueryString["SearchQuery"];
            }

            if(Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1;
            }
            else
            {
                PageIndex = 0;
            }

            if(Request.Cookies["DotNetNote"] != null)
            {
                if (!string.IsNullOrEmpty(Request.Cookies["DotNetNote"]["PageNum"]))
                {
                    PageIndex = Convert.ToInt32(Request.Cookies["DotNetNote"]["PageNum"]);
                }
                else
                {
                    PageIndex = 0;
                }
            }

            if(SearchMode == false)
            {
                RecordCount = _repository.GetCountAll();
            }
            else
            {
                RecordCount = _repository.GetCountBySearch(SearchField, SearchQuery);
            }
            lblTotalRecord.Text = RecordCount.ToString();

            AdvancedPagingSingleWithBootstrap.PageIndex = PageIndex;
            AdvancedPagingSingleWithBootstrap.RecordCount = RecordCount;

            if (!Page.IsPostBack)
            {
                DIsplayData();
            }
        }

        private void DIsplayData()
        {
            if(SearchMode == false)
            {
                ctlBoardList.DataSource = _repository.GetAll(PageIndex);
            }
            else
            {
                ctlBoardList.DataSource = _repository.getSearchAll(PageIndex, SearchField, SearchQuery);
            }
            ctlBoardList.DataBind();
        }
    }
}