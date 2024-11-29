namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating(double value)
    {
        public double Value { get; } = value;
    }
}
