using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SQLConnect
    {
        string dbName = "dbi482774_dfeditor";
        string dbPass = "DFEditor0123";
        internal SqlConnection DbConnection; 

        internal void InitializeDB()
        {
            string connectionString = $"Data Source=mssqlstud.fhict.local;Database={dbName};User Id={dbName};Password={dbPass};MultipleActiveResultSets=true;";
            DbConnection = new SqlConnection(connectionString);
        }

        internal bool OpenConnection()
        {
            try
            {
                InitializeDB();
                DbConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool CloseConnection()
        {
            try
            {
                DbConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}