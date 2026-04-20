using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public Plane() { }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

        public override string ToString()
        {
            return $"Plane Id: {PlaneId}, Type: {PlaneType}, Capacity: {Capacity}, ManufactureDate: {ManufactureDate:yyyy-MM-dd}, Flights: {Flights?.Count ?? 0}";
        }
    }
}