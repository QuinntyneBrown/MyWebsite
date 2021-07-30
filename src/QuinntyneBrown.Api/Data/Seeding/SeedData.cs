using Microsoft.AspNetCore.StaticFiles;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuinntyneBrown.Api.Data
{
    public static class SeedData
    {
        public static void Seed(QuinntyneBrownDbContext context)
        {
            DigitalAssetConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            ProfileConfiguration.Seed(context);
            VideoConfiguration.Seed(context);
        }

        internal static class VideoConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {
                foreach (var video in new List<Video>
                {
                    new Video("Bb4zwjzeA2M","DDD and Event Sourcing using ASP.NET Core, MediatR, SignalR and Angular","")
                })
                {
                    if (context.Videos.SingleOrDefault(x => x.YouTubeVideoId == video.YouTubeVideoId) == null)
                    {
                        video.Publish(new DateTime(2018, 9, 24));

                        context.Add(video);
                    }
                }

                context.SaveChanges();
            }
        }

        internal static class DigitalAssetConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {
                var filename = "QuinntyneBrown.jpg";

                if (context.DigitalAssets.SingleOrDefault(x => x.Name == filename) == null)
                {
                    var provider = new FileExtensionContentTypeProvider();

                    provider.TryGetContentType(filename, out string contentType);

                    var digitalAsset = new DigitalAsset
                    {
                        Name = filename,
                        Bytes = StaticFileLocator.Get(filename),
                        ContentType = contentType
                    };

                    context.DigitalAssets.Add(digitalAsset);

                    context.SaveChanges();
                }
            }
        }

        internal static class ProfileConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {
                Profile profile = context.Profiles.SingleOrDefault(x => x.Fullname == "Quinntyne Brown");

                var digitalAsset = context.DigitalAssets.SingleOrDefault(x => x.Name == "QuinntyneBrown.jpg");

                if (profile == null)
                {
                    profile = new("Fullstack Engineer at RBC Ventures", "Quinntyne Brown", "Description and stuff");

                    profile.SetAvatarDigitalAssetId(digitalAsset.DigitalAssetId);
                    profile.SetLinkedInProfile("https://www.linkedin.com/in/quinntynebrown/");
                    profile.SetGithubProfile("https://github.com/QuinntyneBrown");

                    context.Profiles.Add(profile);

                    context.SaveChanges();
                }
            }
        }

        internal static class UserConfiguration
        {
            internal static void Seed(QuinntyneBrownDbContext context)
            {
                var user = context.Users.SingleOrDefault(x => x.Username == "quinntynebrown@gmail.com");

                if (user == null)
                {
                    user = new("Quinntyne Brown", "quinntynebrown@gmail.com", "P@ssw0rd", new PasswordHasher());

                    context.Users.Add(user);

                    context.SaveChanges();
                }
            }
        }
    }
}
