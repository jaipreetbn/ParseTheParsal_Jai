using static ParseTheParsalLibrary.Models.Package;
using System.Linq;

namespace ParseTheParsalLibrary.BusinessLogic
{
    /// <summary>
    /// Class ParseTheParsalCalculator implementing the interface to provide the rate calculation.
    /// </summary>
    public class ParcelRateCalculator : IParcelRateCalculator
    {
        public ParcelRateCalculator()
        {
            PopulateRatesData();
        }

        /// <summary>
        /// Lenght of Parsal
        /// </summary>
        public decimal Length { get; set; } = decimal.Zero;

        /// <summary>
        /// Breadth of Parsal
        /// </summary>
        public decimal Breadth { get; set; } = decimal.Zero;

        /// <summary>
        /// Height of Parsal
        /// </summary>
        public decimal Height { get; set; } = decimal.Zero;

        /// <summary>
        /// Weight of Parsal
        /// </summary>
        public decimal Weight { get; set; } = decimal.Zero;

        /// <summary>
        /// Implementation as per current business requirement
        /// </summary>
        /// <returns>
        /// </returns>
        public decimal CalculateRate()
        {
            PackageDetail suitablePackage = GetPackageTypeForGivenDimensions(AvailablePackages);

            return suitablePackage.Price;
        }

        #region Privates

        /// <summary>
        /// Method returns the name of most suitable package type for the given dimensions.
        /// </summary>
        /// <returns>
        /// </returns>
        private PackageDetail GetPackageTypeForGivenDimensions(IEnumerable<PackageDetail> availablePackages)
        {
            if (Length > decimal.Zero && Breadth > decimal.Zero && Height > decimal.Zero && Weight > decimal.Zero)
            {
                foreach (var package in availablePackages.Where(package => Length <= package.MaxLength && Breadth <= package.MaxBreadth && Height <= package.MaxHeight && Weight <= package.MaxWeight))
                {
                    return package;
                }
            }
            throw new ArgumentOutOfRangeException("Invalid package size or weight entered.");
        }
        #endregion
    }
}
