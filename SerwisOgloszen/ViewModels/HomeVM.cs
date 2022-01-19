using SerwisOgloszen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisOgloszen.ViewModels
{
    public class HomeVM
    {
        public string Title { get; set; }
        public List<Motorcycle> Motorcycle { get; set; }
    }
}
