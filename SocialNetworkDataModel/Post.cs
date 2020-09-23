using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SocialNetworkDataModel
{
    public class Post
    {
        // TODO: this probably should not be called ID if it's not GUID, but instead some running number

        [JsonPropertyName("id")]
        public int ID { get; set; } // THIS IS NOT GLOBALLY UNIQUE IDENTIFIER

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [Required] // Not necessariy but should return a more clear error message
        [MinLength(3)]
        [MaxLength(300)]

        [JsonPropertyName("content")]
        public string Content { get; set; }

        // Implicit conversion to bool cleans up our code
        public static implicit operator bool(Post obj)
        {
            return !(obj is null);
        }
    }
}
