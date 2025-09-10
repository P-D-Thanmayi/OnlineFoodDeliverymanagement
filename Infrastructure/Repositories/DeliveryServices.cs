using Domain.ADO;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class DeliveryServices
    {
        public Delivery GetDeliveryByOrderId(int id)
        {
            Delivery delivery = null;

            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "SELECT * FROM Delivery WHERE order_id = @OrderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderId", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    delivery = new Delivery
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

        public List<Delivery> GetDeliveriesByAgentId(int AgentId)
        {

            var deliveries = new List<Delivery>();

            using (SqlConnection conn = SqlConn.GetConnection())
            {
                string query = "SELECT * FROM Delivery WHERE agent_id = @AgentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AgentId", AgentId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    deliveries.Add(new Delivery
                    {
                        DeliveryId = Convert.ToInt32(reader["delivery_id"]),
                        OrderId = Convert.ToInt32(reader["order_id"]),
                        Status =(bool) reader["status"],
                        AgentId = Convert.ToInt32(reader["agent_id"])
                    });
                }
                return deliveries;

            }
        }
    }
}

