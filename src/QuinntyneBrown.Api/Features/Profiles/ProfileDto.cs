using System;

namespace QuinntyneBrown.Api.Features
{
    public class ProfileDto
    {
        public Guid ProfileId { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
    }
}
