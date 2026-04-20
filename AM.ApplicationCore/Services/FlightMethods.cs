using System;
using System.Collections.Generic;
using System.Linq;
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
            return filterType switch
            {
                "Destination" => Flights.Where(f => f.Destination == filterValue).ToList(),
                "EstimatedDuration" => Flights.Where(f => f.EstimatedDuration == double.Parse(filterValue)).ToList(),
                _ => new List<Flight>()
            };
        }

        public void ShowFlightDetails(Plane plane)
        {
            Flights.Where(f => f.Plane == plane)
                   .ToList()
                   .ForEach(f => Console.WriteLine($"Date: {f.FlightDate} | Destination: {f.Destination}"));
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return Flights.Count(f => f.FlightDate >= startDate);
        }

        public double DurationAverage(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration)
                .Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        public Flight LongestFlight()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration).FirstOrDefault();
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers
                .OfType<Traveller>()
                .OrderBy(p => p.BirthDate)
                .Take(3);
        }

        public void DestinationGroupedFlights()
        {
            var groups = Flights.GroupBy(f => f.Destination);
            foreach (var group in groups)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH : mm :ss}");
                }
            }
        }

        public void FlightCountByDestination()
        {
            var counts = Flights.GroupBy(f => f.Destination)
                                .Select(g => new { Destination = g.Key, Count = g.Count() });

            foreach (var item in counts)
            {
                Console.WriteLine($"Destination: {item.Destination}, Nombre de vols: {item.Count}");
            }
        }

        public Flight MostOccupiedFlight()
        {
            return Flights.OrderByDescending(f => f.Passengers.Count).FirstOrDefault();
        }

        public IEnumerable<string> GetDestinations()
        {
            return Flights.Select(f => f.Destination).Distinct();
        }

        public bool ExistsParisFlight()
        {
            return Flights.Any(f => f.Destination.Equals("Paris", StringComparison.OrdinalIgnoreCase));
        }
    }
}