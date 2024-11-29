namespace BuberDinner.Domain.Common.Models
{
    public abstract class AggregateRoot<Tid>(Tid id) : Entity<Tid>(id)
        where Tid : notnull
    {
    }
}
