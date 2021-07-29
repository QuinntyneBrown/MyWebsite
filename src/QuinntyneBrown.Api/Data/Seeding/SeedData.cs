using System;

namespace QuinntyneBrown.Api.Data
{
    public static class SeedData
    {
        public static void Seed(QuinntyneBrownDbContext context)
        {
            DigitalAssetConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            ProfileConfiguration.Seed(context);
        }

        internal static class DigitalAssetConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {

            }
        }

        internal static class ProfileConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {

            }
        }

        internal static class UserConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {

            }
        }
    }
}
