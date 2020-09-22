using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetworkDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories
{
    public class PostsRepository
    {
        private ILogger<PostsRepository> _logger;
        private ProfileRepository _profileRepository;

        public PostsRepository(ILogger<PostsRepository> logger, ProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        public List<Post> GetPostsByProfileID(int profileID)
        {
            return _profileRepository.GetProfileById(profileID)?.Posts;
        }

        public Post GetProfilePostByID(int profileID, int postID)
        {
            // TODO: whatever this formatting is
            return _profileRepository.GetProfileById(profileID)?
                .Posts?
                .FirstOrDefault(x => x.ID == postID);
        }

        public void AddNewPostToProfile(int profileID, Post post)
        {
            Profile profile = _profileRepository.GetProfileById(profileID);

            if (profile.Posts is null)
                profile.Posts = new List<Post>();

            post.ID = GetNextPostID(profile.Posts);
            post.Date = DateTime.Now;
            profile.Posts.Add(post);
        }

        public bool DeletePostInProfile(int profileID, int postID)
        {
            List<Post> posts = GetPostsByProfileID(profileID);

            if (posts is null)
                return false;

            if (!GetProfilePostByID(profileID, postID))
                return false; // post does not exist

            _profileRepository.GetProfileById(profileID).Posts = posts.Where(x => x.ID != postID).ToList();
            return true;
        }

        private int GetNextPostID(List<Post> posts)
        {
            if (posts.Count == 0)
                return 0;

            return posts.Last().ID + 1;
        }
    }
}
