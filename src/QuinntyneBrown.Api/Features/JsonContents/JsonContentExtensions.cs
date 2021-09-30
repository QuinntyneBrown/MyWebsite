using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class JsonContentExtensions
    {
        public static JsonContentDto ToDto(this JsonContent jsonContent)
            => new() { JsonContentId = jsonContent.JsonContentId };
    }
}
