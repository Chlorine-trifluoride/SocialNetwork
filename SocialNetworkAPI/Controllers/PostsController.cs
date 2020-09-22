﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetworkAPI.Repositories;
using SocialNetworkDataModel;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/profile/{profileID:int}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly PostsRepository _postsRepository;

        public PostsController(ILogger<PostsController> logger, PostsRepository postsRepository)
        {
            _logger = logger;
            _postsRepository = postsRepository;
        }

        // api/profile/5/posts
        // returns all posts by profile {profileID}
        [HttpGet]
        public ActionResult<List<Post>> GetAllPostsByProfile(int profileID)
        {
            return Ok(_postsRepository.GetPostsByProfileID(profileID));
        }

        // api/profile/5/posts/5
        // returns post {postID} by {profileID}
        [HttpGet("{postID:int}")]
        public ActionResult<Post> GetProfilePostByID(int profileID, int postID)
        {
            Post post = _postsRepository.GetProfilePostByID(profileID, postID);

            if (post)
                return Ok(post);

            return NotFound();
        }

        // api/profile/5/posts
        // Post a new post to the profile
        [HttpPost]
        public IActionResult PostNewPost(int profileID, [FromBody] Post post)
        {
            _postsRepository.AddNewPostToProfile(profileID, post);
            return Created($"{Request.Path}/{post.ID}", post);
        }

        // api/profile/5/posts/5
        // Patch a post in a profile
        [HttpPatch("{postID:int}")]
        public IActionResult PatchPostInProfileID(int profileID, int postID, [FromBody] JsonPatchDocument<PostPatch> postPatch)
        {
            if (_postsRepository.PatchPostInProfile(profileID, postID, postPatch))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{postID}")]
        public IActionResult DeletePostInProfileID(int profileID, int postID)
        {
            if (_postsRepository.DeletePostInProfile(profileID, postID))
                return NoContent();

            return NotFound();
        }
    }
}
