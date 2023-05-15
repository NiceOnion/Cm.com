using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using InterfaceLayer;

namespace DataAccessLayer
{
    public class Account_SQL_DAL : SQLConnect, IAccount
    {
        public Account_SQL_DAL() { InitializeDB(); }
        public bool Create(AccountDTO accountDTO)
        {
            try
            {
                if (OpenConnection())
                {
                    using (DbConnection)
                    {
                        string query = "INSERT INTO Account (Name, Password) VALUES (@name, @password)";
                        using (SqlCommand CMD = new(query, (SqlConnection)DbConnection))
                        {
                            CMD.Parameters.AddWithValue("@name", accountDTO.Name);
                            CMD.Parameters.AddWithValue("@password", accountDTO.Password);
                            CMD.ExecuteScalar();
                        }
                    }
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            catch
            {
                CloseConnection();
                return false;
            }
        }

        public AccountDTO GetByID(int id)
        {
            try
            {
                if (OpenConnection())
                {
                    int? _id = null;
                    string _name = null;
                    string _password = null;
                    using (DbConnection)
                    {
                        string query = "SELECT * FROM Account WHERE ID=@id";

                        using (SqlCommand sqlCommand = new(query, (SqlConnection)DbConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    _id = (int)reader["ID"];
                                    _name = (string)reader["Name"];
                                    _password = (string)reader["Password"];
                                }
                            }
                        }
                            
                    }
                    CloseConnection();
                    return new AccountDTO((int)_id, _name, _password);
                }
                else
                {
                    CloseConnection();
                    return null;
                }
            }
            catch
            {
                CloseConnection();
                return null;
            }
        }

        public AccountDTO Login(AccountDTO accountDTO)
        {
            try
            {
                if (OpenConnection())
                {
                    int? _id = null;
                    string _name = null;
                    string _password = null;
                    using (DbConnection)
                    {
                        string query = "SELECT * FROM Account WHERE Name=@name AND Password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
                        using (SqlCommand sqlCommand = new(query, DbConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@name", accountDTO.Name);
                            sqlCommand.Parameters.AddWithValue("@password", accountDTO.Password);
                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    _id = (int)reader["ID"];
                                    _name = (string)reader["Name"];
                                    _password = (string)reader["Password"];
                                }
                            }
                        }                        
                    }
                    CloseConnection();
                    return new AccountDTO((int)_id, _name, _password);
                }
                else
                {
                    CloseConnection();
                    return null;
                }
            }
            catch
            {
                CloseConnection();
                return null;
            }
        }
    }
}
