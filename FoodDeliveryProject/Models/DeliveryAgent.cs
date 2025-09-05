using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class DeliveryAgent
{
    public int AgentId { get; set; }

    public required bool Status { get; set; }

    public virtual User Agent { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
