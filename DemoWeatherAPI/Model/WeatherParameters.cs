using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeatherAPI.Model
{
    public class WeatherParameters
    {
        /// <summary>
        /// Időjárás röviden
        /// </summary>
        public string main { get; set; }

        /// <summary>
        /// Időjárás részletesen
        /// </summary>
        public string description { get; set; }
    }
}
