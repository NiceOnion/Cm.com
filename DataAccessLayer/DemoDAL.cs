using InterfaceLayer;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO;

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
                string sqlstring = "SELECT Id, Name, Description, AccountID, Visibility FROM Demo WHERE Id = @id";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("id", DemoID);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTO = new DemoDTO(reader.GetString(1), reader.GetInt32(3))
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Visibility = (bool)reader["Visibility"]
                            };
                        }
                    }
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
            finally { CloseConnection(); }

            return demoDTO;
        }

        public DemoDTO GetOneDemoByName(string demoName)
        {
            DemoDTO demoDTO = null;

            try
            {
                OpenConnection();
                string sqlstring = "SELECT Id, Name, Description, AccountID, Visibility FROM Demo WHERE Name = @name";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("name", demoName);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTO = new DemoDTO(reader.GetString(1), reader.GetInt32(3))
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Visibility = (bool)reader["Visibility"]
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
                string sqlstring = "INSERT INTO Demo(Name, Type, Visibility, AccountID, Description) VALUES (@name,@type, @visibility, @accountId, @description)";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("@name", demoDTO.Name);
                sqlCommand.Parameters.AddWithValue("@type", "sms");
                sqlCommand.Parameters.AddWithValue("@visibility", false);
                sqlCommand.Parameters.AddWithValue("@accountId", demoDTO.AccountID);
                sqlCommand.Parameters.AddWithValue("@description", demoDTO.Description);

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
                var command = new SqlCommand("SELECT ID, Name, Visibility, Description, AccountID FROM Demo WHERE Visibility = 1 AND AccountID = @accountId", DbConnection);
                command.Parameters.AddWithValue("accountId", userId);

                SqlDataReader demoReader = command.ExecuteReader();
                while (demoReader.Read())
                {
                    var demo = new DemoDTO(demoReader.GetString(1))
                    {
                        Id = demoReader.GetInt32(0),
                        Description = demoReader["Description"].ToString()
                    };
                    result.Add(demo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { CloseConnection(); }
            return result;
        }

        public bool EditDemo(int DemoID)
        {
            throw new NotImplementedException();
        }
    }
}
