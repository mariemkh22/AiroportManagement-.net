using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{ 
    public enum PlaneType
    {
        Boing, Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType planeType { get; set; }
        public ICollection<Flight> flights { get; set; }

        public override string? ToString()
        {
            return "Capacity:" + Capacity + "ManufactureDate:" + ManufactureDate;
        }

        public Plane()
        {
        }

        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            this.planeType = planeType;
        }
    }
}
