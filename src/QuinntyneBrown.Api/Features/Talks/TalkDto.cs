using System;

namespace QuinntyneBrown.Api.Features
{
    public class TalkDto
    {
        public Guid TalkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
