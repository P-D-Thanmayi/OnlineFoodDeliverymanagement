using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.ADO;
using Infrastructure.Interfaces;
using Domain.DTO;

namespace Infrastructure.Repositories
{
    public class DeliveryAgentService: IDeliveryAgent
    {
        public List<DeliveryAgentDto> GetAvailableAgents()
        {
            List<DeliveryAgentDto> agents = new List<DeliveryAgentDto>();
            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "Select agent_id, status from delivery_agent where status=1";
                SqlCommand cmd= new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    agents.Add(new DeliveryAgentDto
                    {
                        AgentId = Convert.ToInt32(reader["agent_id"]),
                        Status =(bool) reader["status"]
                    });
                }
            }
            return agents;
        }


    }
}
