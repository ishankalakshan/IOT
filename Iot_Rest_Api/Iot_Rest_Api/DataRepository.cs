using Dapper;
using System.Data.SqlClient;

namespace Iot_Rest_Api
{
    public class DataRepository
    {
        private const string _connectionString = "Server=tcp:iit-msc-common-server.database.windows.net,1433;Initial Catalog=db-iot;Persist Security Info=False;User ID=dbo.admin;Password=Intel@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection OpenDbConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private void Update(string sql, object parameters = null)
        {
            using (var db = OpenDbConnection())
            {
                var result = db.Query(sql, parameters);
            }
        }

        public void UpdateMeetingRoomStatus(int id,int status)
        {
            var queryArgs = new
            {
                id,status
            };
            var sql = "UPDATE [dbo].[MeetingRoom] SET Status=@status WHERE Id=@id";
            Update(sql, queryArgs);
        }

    }
}
