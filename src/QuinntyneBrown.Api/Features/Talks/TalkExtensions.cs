using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class TalkExtensions
    {
        public static TalkDto ToDto(this Talk talk)
        {
            return new()
            {
                TalkId = talk.TalkId
            };
        }

    }
}
