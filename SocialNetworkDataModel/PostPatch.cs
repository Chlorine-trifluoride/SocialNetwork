﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SocialNetworkDataModel
{
    public class PostPatch
    {
        public const int MIN_LEN = 3;
        public const int MAX_LEN = 300;

        [Required]
        [StringLength(MAX_LEN, MinimumLength = MIN_LEN)] // This is not working correctly

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
