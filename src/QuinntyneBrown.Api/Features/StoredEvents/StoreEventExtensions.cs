using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class StoredEventExtensions
    {
        public static StoredEventDto ToDto(this StoredEvent storedEvent)
        {
            return new ()
            {
                StoredEventId = storedEvent.StoredEventId
            };
        }
        
    }
}
