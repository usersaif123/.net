using System.Collections.Generic;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    foreach (Flight flight in Flights)
        //    {
        //        if (flight.Destination == destination)
        //        {
        //            result.Add(flight.FlightDate);
        //        }
        //    }
        //    return result;
        //}

        public List<DateTime> GetFlightDates(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                        if (flight.Destination == filterValue)
                            result.Add(flight);
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                        if (flight.EstimatedDuration == double.Parse(filterValue))
                            result.Add(flight);
                    break;
            }
            return result;
        }

        public void ShowFlightDetails(Plane plane)
        {
            var result = from flight in Flights
                         where flight.Plane == plane
                            select flight;

            foreach (var flight in result)
            {
                Console.WriteLine($"Date: {flight.FlightDate} | Destination: {flight.Destination}");
            }
        }
    }
}