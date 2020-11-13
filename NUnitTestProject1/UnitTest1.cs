namespace CabInvoiceGenerator_NUnitTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    public class Tests
    {
        /// <summary>
        /// Givens the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;

            //calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
    }
}