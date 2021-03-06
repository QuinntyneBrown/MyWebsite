using System;
using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class VideoExtensions
    {
        public static VideoDto ToDto(this Video video)
        {
            return new()
            {
                VideoId = video.VideoId,
                Title = video.Title,
                Description = video.Description,
                YouTubeVideoId = video.YouTubeVideoId,
                CoverArtDigitalAssetId = video.CoverArtDigitalAssetId,
                PresentationDigitalAssetId = video.PresentationDigitalAssetId,
                Published = video.Published
            };
        }

    }
}
