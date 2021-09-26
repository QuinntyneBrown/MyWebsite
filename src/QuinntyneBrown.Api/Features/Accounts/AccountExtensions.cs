using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class AccountExtensions
    {
        public static AccountDto ToDto(this Account account)
        {
            return new ()
            {
                AccountId = account.AccountId
            };
        }
        
    }
}
