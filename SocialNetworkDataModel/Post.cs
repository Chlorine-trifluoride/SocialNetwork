using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkDataModel
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        [Required] // Not necessariy but should return a more clear error message
        [MinLength(3)]
        [MaxLength(300)]
        public string Content { get; set; }
    }
}
