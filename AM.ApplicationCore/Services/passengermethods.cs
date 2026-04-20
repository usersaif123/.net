using System;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public static class PassengerMethods
    {
        public static string UpperFullName(this Passenger passenger)
        {
            if (passenger == null) return string.Empty;

            string firstName = string.IsNullOrEmpty(passenger.FirstName) ? string.Empty :
                char.ToUpper(passenger.FirstName[0]) +
                passenger.FirstName.Substring(1).ToLower();

            string lastName = string.IsNullOrEmpty(passenger.LastName) ? string.Empty :
                char.ToUpper(passenger.LastName[0]) +
                passenger.LastName.Substring(1).ToLower();

            return $"{firstName} {lastName}".Trim();
        }
    }
}