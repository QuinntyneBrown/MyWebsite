using System;

namespace QuinntyneBrown.Api.Features
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public string AccountHolderFullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
