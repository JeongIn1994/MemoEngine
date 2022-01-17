using System;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace MemoEngine.DotNetNote.Models
{
    public class NoteCommentRepository
    {
        private SqlConnection con;

        public NoteCommentRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public void AddNoteComment(NoteComment model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BoardId", value: model.BoardId, dbType: DbType.Int32);
            parameters.Add("@Name", value: model.Name, dbType:DbType.String);
            parameters.Add("@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);

            string sql = @"
                Insert Into NoteComments (BoardId, Name, Opinion, Password)
                Values(@BoardId, @Name, @Opinion, @Password);
                Update Notes Set CommentCount = CommentCount + 1
                Where Id = @BoardId";

            con.Execute(sql, parameters, commandType: CommandType.Text);
        }

        public List<NoteComment> GetNoteComments(int boardID)
        {
            return con.Query<NoteComment>(
                "Select * From NoteComments Where BoardId = @BoardId",
                new { BoradId = boardID },
                commandType: CommandType.Text).ToList();
        }

        public int GetCountBy(int boardId, int id, string password)
        {
            return con.Query<int>(@"Select Count(*) From NoteComments
                    Where BoardId = @BoardId And Id = @id And Password = @Password",
                    new { BoardId = boardId, Id = id, Password = password },
                    commandType: CommandType.Text).SingleOrDefault();
        }

        public int DeleteNoteComment(int boardId, int id, string password)
        {
            return con.Execute(@"Delete NoteComments
                Where BoardId = @BoardId And Id = @Id And Password = @Password;
                Update Notes Set CommentCount = CommentCount - 1
                Where Id = @BoardId",
                new { Boardid = boardId, Id = id, Password = password },
                commandType: CommandType.Text);

        }

        public List<NoteComment> getRecentComments()
        {
            string sql = @"Select TOP3 Id, BoardId, Opinion, PostDate
                    From NoteCOmments Order By Id Desc";

            return con.Query<NoteComment>(sql).ToList();
        }
    }
}