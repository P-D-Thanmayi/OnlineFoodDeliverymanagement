using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public required int OrderId { get; set; }

    public required int AgentId { get; set; }

    public required bool Status { get; set; }

    public required virtual DeliveryAgent Agent { get; set; }

    public required virtual Order Order { get; set; }
}
