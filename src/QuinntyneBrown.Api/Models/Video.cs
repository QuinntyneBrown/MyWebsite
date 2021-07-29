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

        public Video(string title, string description)
        {
            Title = title;
            Description = description;
        }

        private Video()
        {

        }
    }
}
