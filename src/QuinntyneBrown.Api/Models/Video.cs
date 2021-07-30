using System;

namespace QuinntyneBrown.Api.Models
{
    public class Video
    {
        public Guid VideoId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid CoverArtDigitalAssetId { get; private set; }
        public string YouTubeVideoId { get; private set; }
        public Guid PresentationDigitalAssetId { get; private set; }
        public DateTime Published { get; private set; }

        public Video(string youTubeVideoId, string title, string description)
        {
            YouTubeVideoId = youTubeVideoId;
            Title = title;
            Description = description;
        }

        private Video()
        {

        }

        public void Publish(DateTime published)
        {
            Published = published;
        }
    }
}
