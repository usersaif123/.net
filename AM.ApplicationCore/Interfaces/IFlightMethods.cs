using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);

        List<Flight> GetFlights(string filterType, string filterValue);

        void ShowFlightDetails(Plane plane);

        double DurationAverage(string destination);

        IEnumerable<Flight> OrderedDurationFlights();

        Flight? LongestFlight();

        IEnumerable<Traveller> SeniorTravellers(Flight flight);

        void DestinationGroupedFlights();

        void FlightCountByDestination();

        Flight? MostOccupiedFlight();

        IEnumerable<string> GetDestinations();

        bool ExistsParisFlight();

    }
}