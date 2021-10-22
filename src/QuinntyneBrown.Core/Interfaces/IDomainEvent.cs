using MediatR;
using System;

namespace QuinntyneBrown.Core.Interfaces
{
    public interface IDomainEvent : INotification
    {
        DateTime Created { get; set; }
    }
}
