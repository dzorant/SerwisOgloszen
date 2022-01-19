using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisOgloszen.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Mileage { get; set; }
        public string EngineSize { get; set; }
        public string Power { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
