using Xunit;
using POE;
using System;
using POE.Pages;

namespace TestPoeClass
{
    public class UnitTest1 : IDisposable
    {
        SendAlertModel testCase; // Assuming PoeClass is the class you want to test

        public UnitTest1()
        {
            // Setup the test
            testCase = new SendAlertModel();
        }

        [Fact]
        public void SendAlert()
        {
            // Arrange
            string expected = "Lunga";

            // Act
            string actual = testCase.SendAlert; // Replace SomeMethod with the actual method you want to test

            // Debugging output
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DonateGoods()
        {
            // Arrange
            string expected = "Lunga";

            // Act
            string actual = testCase.Goods; // Replace SomeMethod with the actual method you want to test

            // Debugging output
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DonateMonetary()
        {
            // Arrange
            string expected = "Lunga";

            // Act
            string actual = testCase.Monetarys; // Replace SomeMethod with the actual method you want to test

            // Debugging output
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Allocate()
        {
            // Arrange
            string expected = "Lunga";

            // Act
            string actual = testCase.Allocate; // Replace SomeMethod with the actual method you want to test

            // Debugging output
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");

            // Assert
            Assert.Equal(expected, actual);
        }

        public void Dispose()
        {
            // Cleanup
            // Close down your test, close the database, etc.
        }

        [Fact]
        public void Test1()
        {
            // Your additional tests go here
        }
    }
}
