using System;

namespace QuinntyneBrown.Api.Features
{
    public class ProfileDto
    {
        public Guid ProfileId { get; set; }
        public string Title { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string GithubProfile { get; set; }
        public string LinkedInProfile { get; set; }
        public Guid AvatarDigitalAssetId { get; set; }
    }
}
