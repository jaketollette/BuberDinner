using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public Location Value { get; } = null!;
    public string Name { get; }
    public string Address { get; }
    public float Latitude { get; }
    public float Longitude { get; }

    private Location(string name, string address, float latitude, float longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location CreateNew(string name, string address, float latitude, float longitude)
    {
        return new Location(name, address, latitude, longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
