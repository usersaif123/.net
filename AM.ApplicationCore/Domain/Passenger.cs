using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNumber { get; set; }
        public string? TelNumber { get; set; }

        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public bool CheckProfile(string firstName, string lastName)
        {
            return string.Equals(FirstName, firstName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(LastName, lastName, StringComparison.OrdinalIgnoreCase);
        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return CheckProfile(firstName, lastName)
                && string.Equals(EmailAddress, email, StringComparison.OrdinalIgnoreCase);
        }

        public bool CheckProfile(Passenger passenger)
        {
            if (passenger == null) return false;
            return CheckProfile(passenger.FirstName, passenger.LastName, passenger.EmailAddress);
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

        public override string ToString()
        {
            return $"Passenger {PassengerId}: {FirstName} {LastName}, Email: {EmailAddress}, Passport: {PassportNumber}, Tel: {TelNumber}, BirthDate: {BirthDate:yyyy-MM-dd}, Flights: {Flights?.Count ?? 0}";
        }
    }
}
