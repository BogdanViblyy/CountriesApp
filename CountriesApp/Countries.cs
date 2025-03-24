using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;


// Country class representing a country with its data
namespace CountriesApp
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; } // path to image for the flag
    }
}
