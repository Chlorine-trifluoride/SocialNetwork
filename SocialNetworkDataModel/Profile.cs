using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetworkDataModel
{
    public class Profile
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(40)]

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }

        [JsonPropertyName("friendIDs")]
        public List<int> FriendIDs { get; set; }

        [JsonPropertyName("posts")]
        public List<Post> Posts { get; set; }

        // Implicit conversion to bool cleans up our code
        public static implicit operator bool(Profile obj)
        {
            return !(obj is null);
        }
    }
}
