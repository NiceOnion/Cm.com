using InterfaceLayer;
using InterfaceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FlowDAL : SQLConnect, IFlow
    {
        public FlowDAL() { InitializeDB(); }

        public bool Edit(FlowDTO flowDTO)
        {
            bool result = false;

            try
            {
                OpenConnection();
                SqlCommand editFlowCommand = new SqlCommand("UPDATE Flow SET " +
                    "Name = @name, " +
                    "Description = @desc, " +
                    "Json = @json " +
                    "WHERE ID = @id", DbConnection);
                editFlowCommand.Parameters.AddWithValue("id", flowDTO.Id);
                editFlowCommand.Parameters.AddWithValue("name", flowDTO.Name);
                editFlowCommand.Parameters.AddWithValue("desc", flowDTO.Description);
                editFlowCommand.Parameters.AddWithValue("json", flowDTO.Json);

                result = editFlowCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { CloseConnection(); }

            return result;
        }

        public FlowDTO GetFlow(int flowId)
        {
            FlowDTO flow = null;
            try
            {
                OpenConnection();

                SqlCommand getOneFlowCom = new SqlCommand("SELECT ID, Name, Description, Json FROM Flow WHERE ID = @id", DbConnection);
                getOneFlowCom.Parameters.AddWithValue("id", flowId);
                var getOneFlowReader = getOneFlowCom.ExecuteReader();
                while (getOneFlowReader.Read())
                {
                    flow = new FlowDTO(getOneFlowReader.GetInt32(0), getOneFlowReader.GetString(1),
                        getOneFlowReader.GetString(2), getOneFlowReader.GetString(3));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { CloseConnection(); }
            return flow;
        }

        public bool AddFlow(int demoId, FlowDTO flowDTO)
        {
            bool result = false;
            try
            {
                OpenConnection();
                var addFlowCommand = new SqlCommand("INSERT INTO Flow (Name, Description, Json, DemoID) VALUES (@name, @desc, @json, @did)", DbConnection);
                addFlowCommand.Parameters.AddWithValue("id", flowDTO.Id);
                addFlowCommand.Parameters.AddWithValue("name", flowDTO.Name);
                addFlowCommand.Parameters.AddWithValue("desc", flowDTO.Description);
                addFlowCommand.Parameters.AddWithValue("json", flowDTO.Json);
                addFlowCommand.Parameters.AddWithValue("did", demoId);
                if (addFlowCommand.ExecuteNonQuery() > 0) result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { CloseConnection(); }
            return result;
        }
    }
}
