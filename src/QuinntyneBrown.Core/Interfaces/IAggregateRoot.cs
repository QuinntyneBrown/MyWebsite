namespace QuinntyneBrown.Core.Interfaces
{
    public interface IAggregateRoot
    {
        AggregateRoot Apply(IDomainEvent @event);
    }
}
