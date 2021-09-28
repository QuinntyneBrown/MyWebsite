using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class TalkExtensions
    {
        public static TalkDto ToDto(this Talk talk)
        {
            return new()
            {
                TalkId = talk.TalkId,
                Title = talk.Title,
                Description = talk.Description,
                Date = talk.Date
            };
        }

    }
}
