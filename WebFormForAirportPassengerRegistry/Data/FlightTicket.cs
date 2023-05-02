using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class FlightTicket
{
    public int FlightTicketId { get; set; }

    public decimal LuggageVolume { get; set; }

    public decimal LuggageWeight { get; set; }

    public string Class { get; set; } = null!;

    public int Seat { get; set; }

    public int? FlightId { get; set; }

    public int? VisaId { get; set; }

    public int? PassengerId { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual Passenger? Passenger { get; set; }

    public virtual Visa? Visa { get; set; }
}
