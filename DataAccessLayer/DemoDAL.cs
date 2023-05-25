using InterfaceLayer;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO;
using System.Diagnostics.CodeAnalysis;

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
                sqlCommand.Parameters.AddWithValue("ID", id);
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
                var command = new SqlCommand("SELECT ID, Name, Visibility, Description, AccountID FROM Demo WHERE Visibility = 1 AND AccountID = @accountId and Deleted_at is NULL", DbConnection);
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

        public List<DemoDTO> GetArchivedDemosOfUser(int userId)
        {
            var demos = new List<DemoDTO>();
            try
            {
                OpenConnection();
                var getArchivedCommand = new SqlCommand("SELECT Id, Name, Description, Visibility, AccountID FROM Demo WHERE AccountID = @uid and Visibility = 0 and Deleted_at is NULL", DbConnection);
                getArchivedCommand.Parameters.AddWithValue("uid", userId);
                var getArchivedReader = getArchivedCommand.ExecuteReader();
                while (getArchivedReader.Read())
                {
                    demos.Add(new DemoDTO(getArchivedReader.GetString(1))
                    {
                        Id = getArchivedReader.GetInt32(0),
                        Description = getArchivedReader.GetString(2),
                        Visibility = getArchivedReader.GetBoolean(3),
                        AccountID = getArchivedReader.GetInt32(4)
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { CloseConnection(); }
            return demos;
        }

        public bool ReinstateDemo(int demoId)
        {
            bool result = false;
            try
            {
                OpenConnection();
                var reinstateDemoCommand = new SqlCommand("UPDATE Demo SET Visibility = 1 WHERE Id = @id", DbConnection);
                reinstateDemoCommand.Parameters.AddWithValue("id", demoId);
                if (reinstateDemoCommand.ExecuteNonQuery() > 0) result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { CloseConnection(); }
            return result;
        }

        public List<FlowDTO> GetFlowsOfDemo(int id)
        {
            var result = new List<FlowDTO>();
            try
            {
                OpenConnection();
                var getFlowsOFDemoCommand = new SqlCommand("SELECT ID, Name, Description, Json, DemoID FROM Flow WHERE DemoID = @id", DbConnection);
                getFlowsOFDemoCommand.Parameters.AddWithValue("id", id);
                var getFlowsOFDemoReader = getFlowsOFDemoCommand.ExecuteReader();
                while (getFlowsOFDemoReader.Read())
                {
                    result.Add(new FlowDTO(getFlowsOFDemoReader.GetInt32(0), getFlowsOFDemoReader.GetString(1),
                        getFlowsOFDemoReader.GetString(2), getFlowsOFDemoReader.GetString(3)));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { CloseConnection(); }
            return result;
        }

        public bool FullDeleteDemo(int id)
        {
            bool result = false;
            try
            {
                OpenConnection();
                var fullDeleteDemo = new SqlCommand("UPDATE Demo SET Deleted_at = GETDATE() WHERE Id = @id", DbConnection);
                fullDeleteDemo.Parameters.AddWithValue("id", id);
                if (fullDeleteDemo.ExecuteNonQuery() > 0) result = true;
            } catch (Exception e){ throw e; }
            finally { CloseConnection(); }
            return result;
        }
    }
}
