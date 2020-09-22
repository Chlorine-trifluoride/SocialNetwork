using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkDataModel
{
    public class PostPatch
    {
        [Required] // Not necessariy but should return a more clear error message
        [MinLength(3)]
        [MaxLength(300)]
        public string Content { get; set; }

        // Implicit conversion to bool cleans up our code
        public static implicit operator bool(PostPatch obj)
        {
            return !(obj is null);
        }
    }
}
