using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkDataModel
{
    public class Profile
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public List<int> FriendIDs { get; set; }
        public List<Post> Posts { get; set; }
    }
}
