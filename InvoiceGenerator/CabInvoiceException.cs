using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            Invalid_Ride_Type, Invalid_Distance,
            Invalid_Time, Null_Rides, Invalid_UserID
        }
        public ExceptionType type;

        ///Parameter Constructor for setting exception Type and throwing Exception
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}