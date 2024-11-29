using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public Price Value { get; private set; } = null!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price CreateNew(decimal amount, string currency)
        {
            return new Price(amount, currency);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
