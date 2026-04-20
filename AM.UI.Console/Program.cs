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
foreach (var flight in fm.Flights)
{
    Console.WriteLine(flight);
}

Console.WriteLine("Test de la methode GetFlightDates: ");
foreach (var item in fm.GetFlightDates("Madrid"))
    Console.WriteLine("La date du vol: " + item);

fm.GetFlights("Destination", "Paris").ForEach(f => Console.WriteLine(f));
Console.WriteLine("Test de la methode ShowFlightDetails: ");
fm.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("Programmed flights:");
Console.WriteLine(fm.ProgrammedFlightNumber(DateTime.Now));

Console.WriteLine("Ordered flights by duration:");
foreach (var f in fm.OrderedDurationFlights())
{
    Console.WriteLine(f);
}

Console.WriteLine("Grouped flights:");
fm.DestinationGroupedFlights();

Console.WriteLine("Flight count by destination:");
fm.FlightCountByDestination();

Console.WriteLine("Most occupied flight:");
Console.WriteLine(fm.MostOccupiedFlight());

Console.WriteLine("Destinations:");
foreach (var d in fm.GetDestinations())
{
    Console.WriteLine(d);
}

Console.WriteLine("Exists Paris flight:");
Console.WriteLine(fm.ExistsParisFlight());

Console.WriteLine("Test UpperFullName:");

Passenger p = new Passenger
{
    FirstName = "john",
    LastName = "doe",
    EmailAddress = "john.doe@example.com"
};

Console.WriteLine(p.UpperFullName());

Console.ReadKey();