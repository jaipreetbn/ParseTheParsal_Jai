namespace ParseTheParsalLibrary.BusinessLogic
{
    /// <summary>
    /// Interface to provide the methods and properties to be implemented by the classes
    /// Assumption is that in future the rate may be calculated in different ways. So we can create a new class to provide the implentation if needed.
    /// </summary>
    public interface IParcelRateCalculator
    {
        decimal Length { get; set; }
        decimal Breadth { get; set; }
        decimal Height { get; set; }
        decimal Weight { get; set; }

        decimal CalculateRate();
    }
}