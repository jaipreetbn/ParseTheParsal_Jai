using ParseTheParsalLibrary.BusinessLogic;
using ParseTheParsalLibrary.Models;

namespace ParseTheParsalTest.BusinessLogic
{
    public class ParcelRateCalculatorTests
    {
        [Fact]
        public void PopulateRatesData_ShouldLoadRates()
        {
            // Arrange 
            int expectedNumberOfPackages = 3;

            // Act
            Package.PopulateRatesData();

            // Assert
            Assert.Equal(expectedNumberOfPackages, Package.AvailablePackages?.Count);
        }

        // Invalid data to test the edge cases
        public static IEnumerable<object[]> InvalidData =>
        new List<object[]>
        {
            new object[] { decimal.MinValue, 300M, 100.7552336M, 25 },
            new object[] { decimal.MaxValue, -2.0M, 420M, 20 },

            // shouldn't have 0 lengh/ breadth
            new object[] { decimal.Zero, decimal.Zero, 420M, 20 },

            // with weight over 25kg
            new object[] { 320M, 520M, 250M, 26 } 
        };

        [Theory]
        [MemberData(nameof(InvalidData))]
        public void GetPackageTypeForGivenDimensions_InvalidDataShouldFail(decimal length, decimal breadth, decimal height, decimal weight)
        {
            // Arrange
            ParcelRateCalculator calculator = new ParcelRateCalculator();
            calculator.Length = length;
            calculator.Breadth = breadth;
            calculator.Height = height;
            calculator.Weight = weight;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateRate());
        }

        [Theory]
        [InlineData(199, 300, 140, 20, 5)] // Small package
        [InlineData(299, 400, 199, 25, 7.5)] // Medium package
        [InlineData(400, 550, 240, 20, 8.5)] // Large package

        public void GetPackageTypeForGivenDimensions_ValidValuesShouldReturnRate(decimal length, decimal breadth, decimal height, decimal weight, decimal expectedRate)
        {
            // Arrange
            ParcelRateCalculator calculator = new ParcelRateCalculator();
            calculator.Length = length;
            calculator.Breadth = breadth;
            calculator.Height = height;
            calculator.Weight = weight;

            // Act
            decimal actualRate = calculator.CalculateRate();

            // Assert
            Assert.Equal(expectedRate, actualRate);
        }
    }
}
