using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FightMethods: IFlightMethods
    {
        //question3 : tp2
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            // declarer et initialisé la liste des dates de vols 
            List<DateTime> resultat = new List<DateTime>();
            // qst 6 on va parcourir la liste de vol boucle for
            /* for(int i=0;i<Flights.Count; i++)
              {
                  if (Flights[i].Destination ==destination)
                  {
                      resultat.Add(Flights[i].FlightDate);
                  }
              }*/
            /// qst 7 foreach 
            foreach (Flight f in Flights)
            {
                if (f.Destination == destination)
                    resultat.Add(f.FlightDate); } }

        //qst 8 
        public void GetFlights(string filterType, string filterValue)
        {
            IEnumerable<Flight> filteredFlights = null;

            switch (filterType)
            {
                case "Destination":
                    filteredFlights = Flights.Where(f => f.Destination == filterValue);
                    break;
                case "Plane":
                    if (Enum.TryParse(filterValue, out PlaneType planeType))
                    {
                        filteredFlights = Flights.Where(f => f.Plane.planeType == planeType);
                    }
                    else
                    {
                        Console.WriteLine("Type d'avion invalide.");
                        return;
                    }
                    break;
                case "FlightDate":
                    if (DateTime.TryParse(filterValue, out DateTime flightDate))
                    {
                        filteredFlights = Flights.Where(f => f.FlightDate.Date == flightDate.Date);
                    }
                    else
                    {
                        Console.WriteLine("Date invalide.");
                        return;
                    }
                    break;
                case "EstimatedDuration":
                    if (int.TryParse(filterValue, out int estimatedDuration))
                    {
                        filteredFlights = Flights.Where(f => f.EstimatedDuration == estimatedDuration);
                    }
                    else
                    {
                        Console.WriteLine("Durée estimée invalide.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Filtre non reconnu.");
                    return;
            }

            if (filteredFlights != null && filteredFlights.Any())
            {
                Console.WriteLine($"Vols filtrés par {filterType} : {filterValue}");
                foreach (var flight in filteredFlights)
                {
                    Console.WriteLine($"Destination: {flight.Destination}, Date: {flight.FlightDate}, Plane: {flight.Plane.planeType}, Duration: {flight.EstimatedDuration} min");
                }
            }
            else
            {
                Console.WriteLine("Aucun vol trouvé pour le filtre spécifié.");
            }
        }

          //link : qst 9 link toujour  retourne une liste ordonnée  


        /*  resultat = from f in Flights where f.Destination==destination
                     select f.FlightDate;
*/

            /// expression lambda
           /* resultat = Flights.Where(f => f.Destination == destination)
              .Select(f => f.FlightDate);
*/

            return resultat;



           // effectuer le test avec la destination passée en paramétre 
           // on va ajouté sa date de vol a la liste des dates des vols 
           // retourner la liste des dates des vols 
        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.plane == plane
                      select new { f.FlightDate, f.Destination };
            foreach(var f in req)
            {
                Console.WriteLine(f);
            }
        }
        // question11
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate) < 0 && (f.FlightDate - startDate).TotalDays < 8
                      select f;
            return req.Count();
        }
        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination == destination
                      select f.EstimatedDuration;
            return req.Average();

        }

        public IEnumerable<Flight> orderedDurationFlights()

        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;

            return req;
           
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from t in  flight.passengers.OfType<Traveller>()
                      orderby t.BirthDate descending
                      select t;
            return req.Take(3);
        }
        
        //question 15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine("Destination:" + g.Key);
                foreach (Flight f in g)
                    Console.WriteLine(f);

            }
            return req;
        }



        //question 16 notion des délégues 
        public Action<Plane> FlighDetailsDel;
        public Func<string, double> DurationAverageDel;
//question 17 et 18
       public FightMethods()
        {
            FlighDetailsDel = pl =>
            {
                var req = from f in Flights
                          where f.plane == pl
                          select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);
            };
        }

    }

}
