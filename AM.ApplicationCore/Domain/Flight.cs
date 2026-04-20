using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public double EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }

        public Plane? Plane { get; set; }
        public int PlaneId { get; set; }

        public IList<Passenger> Passengers { get; set; } = new List<Passenger>();

        public override string ToString()
        {
            var planeInfo = Plane != null ? Plane.PlaneType.ToString() : "No plane";
            return $"Flight {FlightId}: {Departure} -> {Destination}, Date: {FlightDate:yyyy-MM-dd}, Duration: {EstimatedDuration}h, Plane: {planeInfo}, Passengers: {Passengers?.Count ?? 0}";
        }
    }
}
