using System.Collections.Generic;

namespace Cab_Invoice_Generator
{
    public class RideRepository
    {
        /// <summary>
        /// Dictionary to store UserId and Rides int List
        /// </summary>
        Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds the ride.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="Cab_Invoice_Generator.CabInvoiceException">Rides are null</exception>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_Rides, "Rides are null");
            }
        }


        /// <summary>
        /// Function to get rides list as an array for specified UserId 
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Cab_Invoice_Generator.CabInvoiceException"></exception>
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_UserID, "Invalid UserID");
            }
        }

    }
}