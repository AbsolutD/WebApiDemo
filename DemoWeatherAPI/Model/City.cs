using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeatherAPI.Model
{
    public class City
    {
        /// <summary>
        /// Városazonosító
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Városnév
        /// </summary>
        public string name { get; set; }
    }
}
