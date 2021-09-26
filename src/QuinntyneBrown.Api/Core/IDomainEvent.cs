using MediatR;
using System;

namespace QuinntyneBrown.Api.Core
{
    public interface IDomainEvent: INotification
    {
        DateTime Created { get; set; }
    }
}
