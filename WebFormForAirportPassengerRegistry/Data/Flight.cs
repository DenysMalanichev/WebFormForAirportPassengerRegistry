using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class Flight
{
    public int FlightId { get; set; }

    public int SeatsNum { get; set; }

    public DateTime ArrivalTime { get; set; }

    public DateTime DepartureTime { get; set; }

    public string PlaceOfDeparture { get; set; } = null!;

    public string PlaceOfArrival { get; set; } = null!;

    public int? TerminalId { get; set; }

    public virtual ICollection<FlightTicket> FlightTickets { get; set; } = new List<FlightTicket>();

    public virtual Terminal? Terminal { get; set; }
}
