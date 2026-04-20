using AM.ApplicationCore.Domain;
using System;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p)
        {
            if (p == null) return;

            if (!string.IsNullOrEmpty(p.FirstName))
            {
                p.FirstName = char.ToUpper(p.FirstName[0]) + p.FirstName.Substring(1).ToLower();
            }

            if (!string.IsNullOrEmpty(p.LastName))
            {
                p.LastName = char.ToUpper(p.LastName[0]) + p.LastName.Substring(1).ToLower();
            }
        }
    }
}
