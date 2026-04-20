using System;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string? Function { get; set; }
        public double Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a Staff Member");
        }

        public override string ToString()
        {
            return $"Staff {PassengerId}: {FirstName} {LastName}, Function: {Function}, Salary: {Salary}, EmploymentDate: {EmploymentDate:yyyy-MM-dd}";
        }
    }
}
