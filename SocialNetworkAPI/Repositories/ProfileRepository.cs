using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using SocialNetworkDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories
{
    public class ProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;

        private List<Profile> profiles;

        public ProfileRepository(ILogger<ProfileRepository> logger)
        {
            _logger = logger;

            profiles = new List<Profile>();

            // DEBUG
            profiles = Utils.DummyProfiles.GetDummyProfiles();
        }

        public List<Profile> GetProfiles()
        {
            return profiles;
        }

        public Profile GetProfileById(int profileID)
        {
            return profiles.FirstOrDefault(p => p.ID == profileID);
        }

        public bool PatchProfileById(int profileID, JsonPatchDocument<ProfilePatch> profilePatch)
        {
            Profile profile = GetProfileById(profileID);

            if (profile)
            {
                // TODO: All of this seems like unnecessary clutter
                ProfilePatch patchProfile = new ProfilePatch
                {
                    FriendIDs = profile.FriendIDs,
                    ImageURL = profile.ImageURL
                };

                profilePatch.ApplyTo(patchProfile);

                profile.FriendIDs = patchProfile.FriendIDs;
                profile.ImageURL = patchProfile.ImageURL;

                return true;
            }

            return false;
        }
    }
}
