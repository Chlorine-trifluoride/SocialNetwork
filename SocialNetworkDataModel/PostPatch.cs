using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkDataModel
{
    public class PostPatch
    {
        [Required]
        [StringLength(300)] // This is not working correctly
        public string Content { get; set; }
    }
}
