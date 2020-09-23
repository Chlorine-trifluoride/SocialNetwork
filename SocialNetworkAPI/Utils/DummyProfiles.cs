using SocialNetworkDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Utils
{
    public static class DummyProfiles
    {
        public static List<Profile> GetDummyProfiles()
        {
            List<Profile> dummyProfiles = new List<Profile>
            {
                new Profile
                {
                    ID = 0,
                    Name = "Johannes Kantola",
                    ImageURL = "https://discord.com/assets/1cbd08c76f8af6dddce02c5138971129.png",
                    FriendIDs = new List<int>{1, 2},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "It was a beautiful day today."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "I made a cake!"
                        }
                    }
                },
                new Profile
                {
                    ID = 1,
                    Name = "Rene Orosz",
                    ImageURL = "https://cdn.discordapp.com/avatars/265986828132155392/63b6b517dc38c63154c0c4626a786f46.png?size=128",
                    FriendIDs = new List<int>{0, 2},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "I made progress today."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "Feeling good..."
                        }
                    }
                },
                new Profile
                {
                    ID = 2,
                    Name = "Asiakas Assi",
                    ImageURL = "http://www.clker.com/cliparts/e/1/d/1/1513780035272509829example-stamp-vector.med.png",
                    FriendIDs = new List<int>{0, 1},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "Good morning."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "Making coffee."
                        }
                    }
                }
            };

            return dummyProfiles;
        }
    }
}
