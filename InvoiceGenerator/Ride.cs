﻿namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // <summary>
    /// Ride class to set data for particular ride.  
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// The distance
        /// </summary>
        public double distance;

        /// <summary>
        /// The time
        /// </summary>
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