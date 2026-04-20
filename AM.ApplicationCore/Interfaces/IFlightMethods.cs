using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);

        List<Flight> GetFlights(string filterType, string filterValue);

        void ShowFlightDetails(Plane plane);

    }
}