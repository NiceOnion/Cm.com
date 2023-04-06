using InterfaceLayer;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DemoDAL : SQLConnect ,IDemo
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
                sqlCommand.Parameters.AddWithValue("@Name", demoObject.name);
                sqlCommand.Parameters.AddWithValue("@Visibility", demoObject.visibility);
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
        public bool EditDemo(int demoID)
        {
            DemoDTO demoDTO = null;
            try
            {
                OpenConnection();
                string sqlstring = "UPDATE Demo SET Name = @Test,Visibility = @Visibility Where ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlstring);
                sqlCommand.Parameters.AddWithValue("@ID",demoID);
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
                string sqlstring = "SELECT * FROM Demo";
                SqlCommand sqlCommand = new SqlCommand(sqlstring, DbConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            demoDTO = new DemoDTO(Convert.ToString(reader["Name"]));
                            reader.Close();
                        }
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
                sqlCommand.Parameters.AddWithValue("@name", demoDTO.name);
                sqlCommand.ExecuteNonQuery();    
                CloseConnection();
                return true;
            }
            catch (Exception e){ return false;}
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
                    demodto.id = Convert.ToInt32(reader["ID"]);
                    demodto.name = Convert.ToString(reader["Name"]);
                    demodto.visibility = Convert.ToBoolean(reader["Visibility"]);

                    demolist.Add(demodto);
                }
                reader.Close();

                return demolist;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { CloseConnection(); }
        }



    }
}
