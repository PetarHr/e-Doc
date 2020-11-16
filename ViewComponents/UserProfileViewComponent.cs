using Dropbox.Api;
using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View_Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        private const string defaultProfileImage = "https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _config;
        private readonly DropboxClient _dropBoxClient;

        public UserProfileViewComponent(UserManager<ApplicationUser> userManager,
                                        IConfiguration config)
        {
            this.userManager = userManager;
            this._config = config;
            this._dropBoxClient = new DropboxClient(_config.GetConnectionString("DropBoxAccessToken"));
        }
        public async Task<IViewComponentResult> InvokeAsync(string user)
        {
            var userProfile = await userManager.FindByIdAsync(user);
            var userRole = userManager.GetRolesAsync(userProfile).GetAwaiter().GetResult().FirstOrDefault();
            string picturePath;

            if (!string.IsNullOrEmpty(userProfile.ProfilePicture) && userProfile.ProfilePicture != defaultProfileImage)
            {
                picturePath = this._dropBoxClient.Files.GetTemporaryLinkAsync(userProfile.ProfilePicture).Result.Link;
            } else
            {
                picturePath = "https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg";
            }

            var viewModel = new UserProfileViewModel
            {
                FirstName = userProfile.FirstName,
                FamilyName = userProfile.FamilyName,
                Role = userRole, 
                ProfilePicture = picturePath
            };

            return View(viewModel);
        }
    }
}
