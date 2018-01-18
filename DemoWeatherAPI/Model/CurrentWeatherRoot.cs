using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeatherAPI.Model
{
    public class CurrentWeatherRoot
    {
        /// <summary>
        /// Időjárásjelentések listája
        /// </summary>
        public List<WheaterListElement> list { get; set; }

        /// <summary>
        /// Város
        /// </summary>
        public City city { get; set; }

    }
}
