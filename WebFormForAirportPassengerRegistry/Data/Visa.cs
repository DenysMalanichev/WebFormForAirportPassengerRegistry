using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class Visa
{
    public int VisaId { get; set; }

    public string VisaType { get; set; } = null!;

    public DateTime ValidTill { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<FlightTicket> FlightTickets { get; set; } = new List<FlightTicket>();
}
