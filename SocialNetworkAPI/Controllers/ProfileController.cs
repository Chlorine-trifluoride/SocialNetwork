using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly ProfileRepository _profileRepository;

        public ProfileController(ILogger<ProfileController> logger, ProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        // api/profile/
        // returns all profiles
        [HttpGet]
        public ActionResult<List<Profile>> GetAllProfiles()
        {
            return Ok(_profileRepository.GetProfiles());
        }

        // api/profile/5
        // returns profile {id}
        [HttpGet("{profileID:int}")]
        public ActionResult<Profile> GetProfileByID(int profileID)
        {
            Profile profile = _profileRepository.GetProfileById(profileID);

            if (profile)
                return Ok(profile);

            return NotFound();
        }

        // api/profile/5
        // patch profile image and friends list
        [HttpPatch("{profileID:int}")]
        public IActionResult PatchProfileByID(int profileID, [FromBody] JsonPatchDocument<ProfilePatch> profilePatch)
        {
            if (_profileRepository.PatchProfileById(profileID, profilePatch))
                return NoContent();

            return NotFound();
        }
    }
}
