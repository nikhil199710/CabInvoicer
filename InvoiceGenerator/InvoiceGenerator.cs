using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {
        //Variable
        RideType rideType;
        private RideRepository rideRepository;

        //Constants
        private readonly double Min_Cost_Per_km;
        private readonly int Cost_Per_km;
        private readonly double Min_Fare;


        //Constructor to create Repositoru instance
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                //If Ride type is premium then rates set for premium else for normal
                if (rideType.Equals(RideType.Premium))
                {
                    this.Min_Cost_Per_km = 15;
                    this.Cost_Per_km = 2;
                    this.Min_Fare = 20;
                }
                else if (rideType.Equals(RideType.Normal))
                {
                    this.Min_Cost_Per_km = 10;
                    this.Cost_Per_km = 1;
                    this.Min_Fare = 5;
                }
                else
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
            }
        }




        //Function to Calculate Fare
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                //Calculating Total fare
                totalFare = distance * Min_Cost_Per_km + time * Cost_Per_km;
            }
            catch (CabInvoiceException)
            {
                if (distance == 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Distance, "Invalid Distance");
                if (time < 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Time, "Invalid Time");
                else //if (rideType.Equals(null))
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
            }
            return Math.Max(totalFare, Min_Fare);
        }
        /// <summary>
        /// Adds multiple rides.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceException">Rides are null</exception>
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                //Adding Ride To Specific user
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_Rides, "Rides are null");
            }
        }

        /// <summary>
        /// Gets the invoice summary.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">Invalid UserId</exception>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_UserID, "Invalid UserId");
            }
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                //Calculating total Fare for All rides
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_Rides, "Rides are null");
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}