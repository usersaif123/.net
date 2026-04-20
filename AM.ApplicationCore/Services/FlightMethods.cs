//using System;
//using System.Collections.Generic;
//using System.Linq;
//using AM.ApplicationCore.Domain;

//namespace AM.ApplicationCore.Services
//{
//    public class FlightMethods : IFlightMethods
//    {
//        public List<Flight> Flights { get; set; } = new List<Flight>();

//        public List<DateTime> GetFlightDates(string destination)
//        {
//            return Flights
//                .Where(f => f.Destination == destination)
//                .Select(f => f.FlightDate)
//                .ToList();
//        }

//        public List<Flight> GetFlights(string filterType, string filterValue)
//        {
//            List<Flight> result = new List<Flight>();

//            switch (filterType)
//            {
//                case "Destination":
//                    foreach (Flight flight in Flights)
//                        if (flight.Destination == filterValue)
//                            result.Add(flight);
//                    break;

//                case "EstimatedDuration":
//                    foreach (Flight flight in Flights)
//                        if (flight.EstimatedDuration == double.Parse(filterValue))
//                            result.Add(flight);
//                    break;
//            }

//            return result;
//        }

//        public void ShowFlightDetails(Plane plane)
//        {
//            var result = from flight in Flights
//                         where flight.Plane.PlaneId == plane.PlaneId
//                         select flight;

//            foreach (var flight in result)
//            {
//                Console.WriteLine($"Date: {flight.FlightDate} | Destination: {flight.Destination}");
//            }
//        }

//        public int ProgrammedFlightNumber(DateTime startDate)
//        {
//            var result = from f in Flights
//                         where f.FlightDate >= startDate
//                         select f;

//            return result.Count();
//        }

//        public double DurationAverage(string destination)
//        {
//            var result = from f in Flights
//                         where f.Destination == destination
//                         select f.EstimatedDuration;

//            return result.Any() ? result.Average() : 0;
//        }

//        public List<Flight> OrderedDurationFlights()
//        {
//            var result = from f in Flights
//                         orderby f.EstimatedDuration descending
//                         select f;

//            return result.ToList();
//        }

//        public Flight LongestFlight()
//        {
//            var result = from f in Flights
//                         orderby f.EstimatedDuration descending
//                         select f;

//            return result.FirstOrDefault();
//        }

//        public List<Traveller> SeniorTravellers(Flight flight)
//        {
//            var result = from t in flight.Passengers.OfType<Traveller>()
//                         orderby t.BirthDate ascending
//                         select t;

//            return result.Take(3).ToList();
//        }

//        public void DestinationGroupedFlights()
//        {
//            var result = from f in Flights
//                         group f by f.Destination into g
//                         select g;

//            foreach (var group in result)
//            {
//                Console.WriteLine($"Destination {group.Key}");

//                foreach (var flight in group)
//                {
//                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
//                }
//            }
//        }

//        public void FlightCountByDestination()
//        {
//            var result = from f in Flights
//                         group f by f.Destination into g
//                         select new
//                         {
//                             Destination = g.Key,
//                             Count = g.Count()
//                         };

//            foreach (var item in result)
//            {
//                Console.WriteLine($"{item.Destination} : {item.Count} vols");
//            }
//        }

//        public Flight MostOccupiedFlight()
//        {
//            var result = from f in Flights
//                         orderby f.Passengers.Count descending
//                         select f;

//            return result.FirstOrDefault();
//        }

//        public List<string> GetDestinations()
//        {
//            var result = from f in Flights
//                         select f.Destination;

//            return result.Distinct().ToList();
//        }

//        public bool ExistsParisFlight()
//        {
//            var result = from f in Flights
//                         where f.Destination == "Paris"
//                         select f;

//            return result.Any();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new();

        public List<DateTime> GetFlightDates(string destination) =>
            Flights.Where(f => f.Destination == destination)
                   .Select(f => f.FlightDate)
                   .ToList();

        public List<Flight> GetFlights(string filterType, string filterValue) =>
            filterType switch
            {
                "Destination" => Flights.Where(f => f.Destination == filterValue).ToList(),
                "EstimatedDuration" => Flights.Where(f => f.EstimatedDuration == double.Parse(filterValue)).ToList(),
                _ => new List<Flight>()
            };

        public void ShowFlightDetails(Plane plane)
        {
            Flights.Where(f => f.Plane?.PlaneId == plane.PlaneId)
                   .ToList()
                   .ForEach(f => Console.WriteLine($"Date: {f.FlightDate} | Destination: {f.Destination}"));
        }

        public int ProgrammedFlightNumber(DateTime startDate) =>
            Flights.Count(f => f.FlightDate >= startDate);

        public double DurationAverage(string destination) =>
            Flights.Where(f => f.Destination == destination)
                   .Select(f => f.EstimatedDuration)
                   .DefaultIfEmpty(0)
                   .Average();

        public IEnumerable<Flight> OrderedDurationFlights() =>
            Flights.OrderByDescending(f => f.EstimatedDuration);

        public Flight? LongestFlight() =>
            Flights.OrderByDescending(f => f.EstimatedDuration).FirstOrDefault();

        public IEnumerable<Traveller> SeniorTravellers(Flight flight) =>
            flight.Passengers.OfType<Traveller>()
                             .OrderBy(t => t.BirthDate)
                             .Take(3);

        public void DestinationGroupedFlights()
        {
            Flights.GroupBy(f => f.Destination)
                   .ToList()
                   .ForEach(g =>
                   {
                       Console.WriteLine($"Destination {g.Key}");
                       g.ToList().ForEach(f =>
                           Console.WriteLine($"Décollage : {f.FlightDate:dd/MM/yyyy HH:mm:ss}"));
                   });
        }

        public void FlightCountByDestination()
        {
            Flights.GroupBy(f => f.Destination)
                   .Select(g => new { g.Key, Count = g.Count() })
                   .ToList()
                   .ForEach(x => Console.WriteLine($"{x.Key} : {x.Count} vols"));
        }

        public Flight? MostOccupiedFlight() =>
            Flights.OrderByDescending(f => f.Passengers.Count).FirstOrDefault();

        public IEnumerable<string> GetDestinations() =>
            Flights.Select(f => f.Destination).OfType<string>().Distinct();

        public bool ExistsParisFlight() =>
            Flights.Any(f => f.Destination == "Paris");
    }
}