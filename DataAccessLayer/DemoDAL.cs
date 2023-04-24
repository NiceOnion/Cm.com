using InterfaceLayer;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DemoDAL : SQLConnect, IDemo
    {
        public DemoDAL() { InitializeDB(); }
        public bool SaveDemo(DemoDTO demoObject)
        {
            DemoDTO demoDTO = null;
            try
            {

                OpenConnection();
                string sqlstring = "INSERT INTO [Demo] ([Name], [Visibility], AccountID) VALUES(@Name, @Visibility, 1)";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("@Name", demoObject.Name);
                sqlCommand.Parameters.AddWithValue("@Visibility", demoObject.Visibility);
                return sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }
        public bool EditDemo(DemoDTO demoDTO)
        {            
            try
            {
                OpenConnection();
                string sqlstring = "UPDATE Demo SET Name = @Name, Visibility = @Visibility, Description = @Description WHERE ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("@ID", demoDTO.Id);
                sqlCommand.Parameters.AddWithValue("@Name", demoDTO.Name);
                sqlCommand.Parameters.AddWithValue("@Visibility", demoDTO.Visibility);
                sqlCommand.Parameters.AddWithValue("@Description", demoDTO.Description);
                sqlCommand.ExecuteNonQuery();               
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }

        public DemoDTO GetOneDemo(int DemoID)
        {
            DemoDTO demoDTO = null;

            try
            {
                OpenConnection();
                string sqlstring = "SELECT Id, Name, AccountID FROM Demo WHERE Id = @id";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("id", DemoID);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTO = new DemoDTO(reader.GetString(1), reader.GetInt32(2))
                            {
                                Id = reader.GetInt32(0)
                            };
                        }
                    }
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
            finally { CloseConnection(); }

            return demoDTO;
        }

        public bool NewDemo(DemoDTO demoDTO)
        {
            try
            {
                OpenConnection();
                string sqlstring = "INSERT INTO Demo(Name) VALUES (@name)";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("@name", demoDTO.Name);
                sqlCommand.ExecuteNonQuery();    
                CloseConnection();
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteDemo(int id)
        {
            try
            {
                OpenConnection();
                string sqlstring = " update Demo set Visibility='False' Where ID=@ID";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                return sqlCommand.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }

        }

        public List<DemoDTO> GetDemoList()
        {
            try
            {
                List<DemoDTO> demolist = new List<DemoDTO>();

                string query = "select * from [Demo] where Visibility='True'";
                SqlCommand sqlCommand = new SqlCommand(query, DbConnection);


                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DemoDTO demodto = new DemoDTO();
                    demodto.Id = Convert.ToInt32(reader["ID"]);
                    demodto.Name = Convert.ToString(reader["Name"]);
                    demodto.Visibility = Convert.ToBoolean(reader["Visibility"]);
                    demolist.Add(demodto);
                }
                reader.Close();

                return demolist;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                CloseConnection();
            }
        }
        public List<DemoDTO> GetDemosOfUser(int userId)
        {
            //InitializeDB();
            var result = new List<DemoDTO>();
            try
            {
                OpenConnection();
                var command = new SqlCommand("SELECT ID, Name, Visibility, AccountID FROM Demo WHERE Visibility = 1 AND AccountID = @accountId", DbConnection);
                command.Parameters.AddWithValue("accountId", userId);

                SqlDataReader demoReader = command.ExecuteReader();
                while (demoReader.Read())
                {
                    result.Add(new DemoDTO(demoReader.GetString(1)) { Id = demoReader.GetInt32(0) });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { CloseConnection(); }
            return result;
        }
    }
}
