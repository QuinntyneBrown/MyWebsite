using System;

namespace QuinntyneBrown.Api.Features
{
    public class DigitalAssetDto
    {
        public System.Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}
