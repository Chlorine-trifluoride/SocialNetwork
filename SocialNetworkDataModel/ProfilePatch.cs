using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkDataModel
{
    public class ProfilePatch
    {
        public string ImageURL { get; set; }
        public List<int> FriendIDs { get; set; }

        // Implicit conversion to bool cleans up our code
        public static implicit operator bool(ProfilePatch obj)
        {
            return !(obj is null);
        }
    }
}
