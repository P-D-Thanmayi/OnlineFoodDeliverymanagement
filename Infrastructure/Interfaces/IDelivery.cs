using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Infrastructure.Interfaces
{
    public interface IDelivery
    {
        DeliveryDto GetDeliveryByOrderId(int id);
        List<DeliveryDto> GetDeliveriesByAgentId(int AgentId);
        bool UpdateDeliveryStatus(int DeliveryId);

    }
}
