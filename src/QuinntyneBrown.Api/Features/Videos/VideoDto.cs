using System;

namespace QuinntyneBrown.Api.Features
{
    public class VideoDto
    {
        public Guid VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CoverArtDigitalAssetId { get; set; }
        public string YouTubeVideoId { get; set; }
        public Guid PresentationDigitalAssetId { get; set; }
    }
}
