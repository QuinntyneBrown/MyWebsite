using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class VideoExtensions
    {
        public static VideoDto ToDto(this Video video)
        {
            return new()
            {
                VideoId = video.VideoId
            };
        }

    }
}
