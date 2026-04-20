using System;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

Plane plane1 = new Plane { PlaneId = 1, Capacity = 250, ManufactureDate = DateTime.Now };
Plane plane3 = new Plane { PlaneId = 3, Capacity = 350, ManufactureDate = DateTime.Now };

Console.WriteLine(plane1);
Console.WriteLine(plane3);

Passenger passenger = new Passenger { FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com" };

Console.WriteLine("Test de la méthode ChechProfile1:");
Console.WriteLine(passenger.CheckProfile("Doe", "John"));

Console.WriteLine("Test de la méthode ChechProfile2:");
Console.WriteLine(passenger.CheckProfile("Doe", "John", "john.doe@example.com"));

Staff staff = new Staff();
Traveller traveller = new Traveller();

passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();

FlightMethods fm = new FlightMethods
{ 
    Flights = TestData.listFlights
};

Console.WriteLine("***Test de methode getFlights");
foreach(var flight in fm.Flights)
{
    Console.WriteLine(flight);
}

Console.WriteLine("Test de la methode GetFlightDates: ");
foreach (var item in fm.GetFlightDates("Madrid"))
    Console.WriteLine("La date du vol: " + item);

fm.GetFlights("Destination", "Paris").ForEach(f => Console.WriteLine(f));

Console.WriteLine("Test de la methode GetFlightDates: ");
fm.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("Test de la methode DurationAverage: ");
Console.WriteLine("La moyenne de durée des vols vers Madrid est : " + fm.DurationAverage("Madrid"));

Console.WriteLine("\n*** Test de la méthode OrderedDurationFlights ***");
foreach (var f in fm.OrderedDurationFlights())
{
    Console.WriteLine(f);
}

Console.WriteLine("\n*** Test de la méthode LongestFlight ***");
Console.WriteLine(fm.LongestFlight());

Console.WriteLine("\n*** Test de la méthode SeniorTravellers ***");
var seniorTravellers = fm.SeniorTravellers(TestData.listFlights[0]);
foreach (var t in seniorTravellers)
{
    Console.WriteLine(t);
}

Console.WriteLine("\n*** Test de la méthode DestinationGroupedFlights ***");
fm.DestinationGroupedFlights();

Console.WriteLine("\n*** Test de la méthode FlightCountByDestination ***");
fm.FlightCountByDestination();

Console.WriteLine("\n*** Test de la méthode MostOccupiedFlight ***");
Console.WriteLine(fm.MostOccupiedFlight());

Console.WriteLine("\n*** Test de la méthode GetDestinations ***");
foreach (var dest in fm.GetDestinations())
{
    Console.WriteLine(dest);
}

Console.WriteLine("\n*** Test de la méthode ExistsParisFlight ***");
Console.WriteLine("Existe-t-il un vol vers Paris ? " + fm.ExistsParisFlight());

Console.WriteLine("\n*** Test de la méthode d'extension UpperFullName ***");
Passenger pTest = new Passenger { FirstName = "steve", LastName = "jobs" };
Console.WriteLine("Avant UpperFullName: " + pTest.FirstName + " " + pTest.LastName);
pTest.UpperFullName();
Console.WriteLine("Après UpperFullName: " + pTest.FirstName + " " + pTest.LastName);

Console.ReadKey();