namespace ParseTheParsalLibrary.Models
{
    public static class Package
    {
        public static List<PackageDetail>? AvailablePackages { get; set; }

        /// <summary>
        /// For this exercise, hard-coding data here. Ideally, this method would query the DB/repository to fetch package's sizes/rates data.
        /// </summary>
        public static void PopulateRatesData()
        {
            AvailablePackages?.Clear();
            List<PackageDetail> packageDetails = new List<PackageDetail>
            {
                // We populate the list in the ascending order of the dimensions/prices so that we quickly find and use the first matching one when iterating through the list 
                new PackageDetail { PackageID = 1, Name = "Small", MaxLength = 200M, MaxBreadth = 300M, MaxHeight = 150M, MaxWeight = 25, Price = 5M },
                new PackageDetail { PackageID = 2, Name = "Medium", MaxLength = 300M, MaxBreadth = 400M, MaxHeight = 200M, MaxWeight = 25, Price = 7.5M },
                new PackageDetail { PackageID = 3, Name = "Large", MaxLength = 400M, MaxBreadth = 600M, MaxHeight = 250M, MaxWeight = 25, Price = 8.5M }
            };
            AvailablePackages = packageDetails;
        }

        /// <summary>
        /// A struct to represent a Package entity, as it would be in the DB
        /// </summary>
        public struct PackageDetail
        {
            public int PackageID { get; set; }
            public string Name { get; set; }
            public decimal MaxLength { get; set; }
            public decimal MaxBreadth { get; set; }
            public decimal MaxHeight { get; set; }
            public decimal MaxWeight { get; set; }
            public decimal Price { get; set; }
        }
    }
}
