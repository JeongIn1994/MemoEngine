using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.DotNetNote.Models
{
    public class NoteRepository
    {
        private SqlConnection con;

        public NoteRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public int SaveOrUpdate(Note note, BoardWriteFormType formType)
        {
            int result = 0;

            var parameter = new DynamicParameters();

            parameter.Add("@Name", value: note.Name, dbType: DbType.String);
            parameter.Add("@Email", value: note.Email, dbType: DbType.String);
            parameter.Add("@Title", value: note.Title, dbType: DbType.String);
            parameter.Add("@Content", value: note.Content, dbType: DbType.String);
            parameter.Add("@Password", value: note.Password, dbType: DbType.String);
            parameter.Add("@Encoding", value: note.Encoding, dbType: DbType.String);
            parameter.Add("@Homepage", value: note.Homepage, dbType: DbType.String);
            parameter.Add("@FileName", value: note.FileName, dbType: DbType.String);
            parameter.Add("@FileSize", value: note.FileSize, dbType: DbType.Int32);

            switch (formType)
            {
                case BoardWriteFormType.Write:

                    parameter.Add("@PostIp", value: note.PostIp, dbType: DbType.String);

                    result = con.Execute("WriteNote", parameter, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Modify:
                    parameter.Add("@ModifyIp", value: note.ModifyIp, dbType: DbType.String);
                    parameter.Add("@Id", value: note.Id, dbType: DbType.Int32);

                    result = con.Execute("ModifyNote", parameter, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Reply:
                    parameter.Add("@PostIp", value: note.PostIp, dbType: DbType.String);
                    parameter.Add("@ParentNum", value: note.ParentNum, dbType: DbType.Int32);                  

                    result = con.Execute("ReplyNote", parameter, commandType: CommandType.StoredProcedure);
                    break;

            }

            return result;
        }

        public void Add(Note note)
        {
            try
            {
                SaveOrUpdate(note, BoardWriteFormType.Write);
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        public int UpdateNote(Note note)
        {
            int result = 0;

            try
            {
                result = SaveOrUpdate(note, BoardWriteFormType.Modify);
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return result;
        }
        public void ReplyNote(Note note)
        {
            try
            {
                SaveOrUpdate(note, BoardWriteFormType.Reply);
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public List<Note> GetAll(int page)
        {
            try
            {
                var parameters = new DynamicParameters(new { Page = page });

                return con.Query<Note>("ListNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public int GetCountBySearch(string searchField, string searchQuery)
        {
            try
            {
                return con.Query<int>("SearchNoteCount", new
                {
                    searchField = searchField,
                    searchQuery = searchQuery
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();                
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public int GetCountAll()
        {
            try
            {
                return con.Query<int>(
                    "Select Count(*) From Notes").SingleOrDefault();
            }
            catch(System.Exception)
            {
                return -1;
            }
        }

        public string GetFileNameById(int id)
        {
            return con.Query<string>("Select FileName From Notes Where Id = @Id", new { Id = id }).SingleOrDefault();
        }

        public List<Note> getSearchAll(int page, string searchField, string searchQuery)
        {
            var parameters = new DynamicParameters(new
            {
                Page = page,
                SearchField = searchField,
                SearchQuery = searchQuery
            });

            return con.Query<Note>("SearchNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public void UpdateDownCount(string fileName)
        {
            con.Execute("Update Notes Set DownCount = DownCount + 1"
                + "Where FileName = @FileName", new { FileName = fileName });
        }
        public void UpdateDownCountById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            con.Execute("Update Notes Set DownCount = DownCount + 1"
                + "Where Id = @Id", parameters, commandType: CommandType.StoredProcedure);
        }

        public Note GetNoteById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });

            return con.Query<Note>("ViewNote", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        public int DeleteNote(int id,string password)
        {
            return con.Execute("DeleteNote", new { Id = id, Password = password }, commandType: CommandType.StoredProcedure);
        }

        public List<Note> GetNewPhotos()
        {
            string sql = "Select Top 4 Id, Title, FileName, FileSize From Notes"
                + "Where FileName Like '%.png' Or FileName Like '%.jpg' Or"
                + "FileName Like '%.jpeg' Or FileName Like '%.gif' "
                + "Order By Id Desc";

            return con.Query<Note>(sql).ToList();
        }

        public List<Note> GetNoteSummaryByCategory(string category)
        {
            string sql = "Select TOP3 Id, Title, Name, PostDate, FileName,"
                + "FileSize, ReadCount, CommentCount, Step "
                + "From Notes"
                + "Where Category = @Category Order By Id Desc";

            return con.Query<Note>(sql, new { Category = category }).ToList();
        }

        public List<Note> GetRecentPosts()
        {
            string sql = "Select TOP 3 Id, Title, Name, PostDate, From Notes"
                + "Order By Id Desc";

            return con.Query<Note>(sql).ToList();
        }

        public List<Note> GetRecentPosts(int numberOfNotes)
        {
            string sql = $"Select Top {numberOfNotes} Id, Title, Name, PostDate"
                + "From Notes Order By Id Desc";

            return con.Query<Note>(sql).ToList();
        }
    }
}