namespace QuinntyneBrown.Api.Core
{
    public interface IAggregateRoot
    {
        AggregateRoot Apply(IDomainEvent @event);
    }
}
