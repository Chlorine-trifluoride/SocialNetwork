using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetworkDataModel
{
    public class ProfilePatch
    {

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }

        [JsonPropertyName("friendIDs")]
        public List<int> FriendIDs { get; set; }

        // Implicit conversion to bool cleans up our code
        public static implicit operator bool(ProfilePatch obj)
        {
            return !(obj is null);
        }
    }
}
