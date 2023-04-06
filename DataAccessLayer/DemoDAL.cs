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

            try
            {
                OpenConnection();
                string sqlstring = "SELECT Name, Visibility, AccountID FROM Demo WHERE AccountID = @userId AND Visibility = 1";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                sqlCommand.Parameters.AddWithValue("userId", userID);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTOs.Add(new DemoDTO(reader.GetString(0), reader.GetInt32(2), reader.GetBoolean(1)));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
            finally { CloseConnection(); }
            return demoDTOs;
        }
        public bool EditDemo(int demoID)
        {
            try
            DemoDTO demoDTO = null;
            {
                OpenConnection();
                string sqlstring = "UPDATE Demo SET Name = @Test,Visibility = @Visibility Where ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlstring);
                sqlCommand.Parameters.AddWithValue("@ID", demoID);
                sqlCommand.ExecuteNonQuery();


            }
            catch (Exception Exception)
                Console.WriteLine(Exception.Message);
            {
                throw;
            }
            {
            finally
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
                string sqlstring = "SELECT Mame, AccountID FROM Demo";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTO = new DemoDTO(reader.GetString(0), reader.GetInt32(1));
                        }
                        reader.Close();
                    }
                }
                CloseConnection();
                return demoDTO;
            }
            catch (Exception e) { return null; }
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

                    DemoDTO demodto = new DemoDTO(Convert.ToString(reader["Name"]), Convert.ToBoolean(reader["Visibility"]))
                    {
                        Id = Convert.ToInt32(reader["ID"])
                    };

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
            //try
            //{
            OpenConnection();
            var command = new SqlCommand("SELECT Name, Visibility, AccountID FROM Demo WHERE Visibility = 1 AND AccountID = @accountId", DbConnection);
            command.Parameters.AddWithValue("accountId", userId);

            SqlDataReader demoReader = command.ExecuteReader();
            while (demoReader.Read())
            {
                result.Add(new DemoDTO(demoReader.GetString(0)));
            }
            //} catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            //finally { CloseConnection(); }
            return result;
        }
    }
}
