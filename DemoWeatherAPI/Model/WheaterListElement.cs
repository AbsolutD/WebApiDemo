using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeatherAPI.Model
{
    public class WheaterListElement
    {
        /// <summary>
        /// Elsődleges paraméterek
        /// </summary>
        public MainParameters main { get; set; }

        /// <summary>
        /// Időjárási paraméterek
        /// </summary>
        public List<WeatherParameters> weather { get; set; }

        /// <summary>
        /// Dátum
        /// </summary>
        public string dt_txt { get; set; }

    }
}
