using Cab_Invoice_Generator;
using NUnit.Framework;

namespace CabInvoiceTest
{
    public class Tests
    {
        //InvoiceGenerator Reference
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Given distance and time return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceTime_ReturnTotalFare()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.Normal);
            double distance = 2.0;
            int time = 5;

            //Calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// Given invalid ride throw exception.
        /// </summary>
        [Test]
        public void GivenInvalidRide_ThrowException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            double distance = 2.0;
            int time = 5;
            string expected = "Invalid Ride Type";

            try
            {
                invoiceGenerator = new InvoiceGenerator(RideType.NULL);
                //Calculating fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException e)
            {
                //Asserting Values
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// Given invalid distance throw exception.
        /// </summary>
        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            double distance = 0;
            int time = 5;
            string expected = "Invalid Distance";

            try
            {
                invoiceGenerator = new InvoiceGenerator(RideType.Normal);
                //Calculating fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException e)
            {
                //Asserting Values
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// Given invalid time throw exception.
        /// </summary>
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            double distance = 2.0;
            int time = 0;
            string expected = "Invalid Time";

            try
            {
                invoiceGenerator = new InvoiceGenerator(RideType.Normal);
                //Calculating fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException e)
            {
                //Asserting Values
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}