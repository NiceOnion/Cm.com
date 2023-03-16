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
    }
}
