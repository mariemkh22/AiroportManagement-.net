using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaine;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods

    {
        // IEnumerable parcourir la liste et retourne la liste des dates 
        IEnumerable<DateTime> GetFlightDates(string destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> orderedDurationFlights();
        IEnumerable<Traveller> SeniorTravellers(Flight flight); /// pour ignorer les 3 passagers (.skip(3) au lieu de take(3)); 
        //// question 15
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();


    //question 16 notion des délégues 
    
    }
}
