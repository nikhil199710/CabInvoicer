using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Ride
    {
        /// <summary>
        /// Distance and Time variables initiated
        /// </summary>
        public double distance;
        public int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}