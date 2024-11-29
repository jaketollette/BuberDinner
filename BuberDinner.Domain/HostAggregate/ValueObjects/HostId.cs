using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(string hostId)
    {
        return new HostId(hostId);
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid().ToString());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
