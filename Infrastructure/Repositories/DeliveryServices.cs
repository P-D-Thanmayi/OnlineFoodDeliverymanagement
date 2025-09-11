using Domain.ADO;
using Domain.DTO;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class DeliveryServices: IDelivery
    {
        public DeliveryDto GetDeliveryByOrderId(int id)
        {
            DeliveryDto delivery = null;

            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "SELECT * FROM Delivery WHERE order_id = @OrderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderId", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    delivery = new DeliveryDto
                    {
                        DeliveryId = Convert.ToInt32(reader["delivery_id"]),
                        OrderId = Convert.ToInt32(reader["order_id"]),
                        Status = (bool)reader["status"],
                        AgentId = Convert.ToInt32(reader["agent_id"])
                    };
                }
                reader.Close();
            }
            return delivery;
        }

        public List<DeliveryDto> GetDeliveriesByAgentId(int AgentId)
        {
            var deliveries = new List<DeliveryDto>();

            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "SELECT * FROM Delivery WHERE agent_id = @AgentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AgentId", AgentId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    deliveries.Add(new DeliveryDto
                    {
                        DeliveryId = Convert.ToInt32(reader["delivery_id"]),
                        OrderId = Convert.ToInt32(reader["order_id"]),
                        Status = (bool)reader["status"],
                        AgentId = Convert.ToInt32(reader["agent_id"])
                    });
                }
                return deliveries;

            }
        }

        public bool UpdateDeliveryStatus(int DeliveryId)
        {
            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "Update delivery set status =1 where delivery_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",DeliveryId);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}

