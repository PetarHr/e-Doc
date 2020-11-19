
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using eDoc.Data;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace eDoc.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;
        private readonly DropboxClient _dropBoxClient;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db,
            IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
            this._config = config;
            this._dropBoxClient = new DropboxClient
                (_config.GetConnectionString("DropBoxAccessToken"));
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public string ProfilePicture { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }
            public IFormFile ProfilePicture { get; set; }

            [Display(Name = "Адрес")]
            public Address UserAddress { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userProfile = await _userManager.GetUserAsync(this.User);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userProfile.UserName;

            var userAddress = this._db.Addresses.Where(x => x.Id == userProfile.AddressId).FirstOrDefault();

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                UserAddress = userAddress
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не може да се намери профил с име '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не може да се намери профил с име '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Възникна неочаквана грешка при промяната на телефонния номер.";
                    return RedirectToPage();
                }
            }

            if (Input.ProfilePicture != null)
            {
                user.ProfilePicture = await UploadProfilePictureAsync(user);
            }

            if (Input.UserAddress != null)
            {
                user.Address = Input.UserAddress;
                user.Address.Country = new Country { Name = Input.UserAddress.Country.Name };
                user.Address.Region = new Region { Name = Input.UserAddress.Region.Name };
                user.Address.Municipality = new Municipality { Name = Input.UserAddress.Municipality.Name };
            }
            

            this._db.Users.Update(user);
            await this._db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = $"Профилът е обновен успешно.";
            return RedirectToPage();
        }

        private async Task<string> UploadProfilePictureAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            FileMetadata response;

            byte[] content;
            using (var reader = new BinaryReader(Input.ProfilePicture.OpenReadStream()))
            {
                content = reader.ReadBytes((int)Input.ProfilePicture.Length);
            }

            using (var memoryStream = new MemoryStream(content))
            {
                var folderList = await _dropBoxClient.Files.ListFolderAsync(string.Empty, true, true, false, false, false, null, null, null, true);

                if (folderList.Entries.Where(f => f.Name == userName.ToLower()).Count() == 0)
                {
                    var folder = await _dropBoxClient.Files.CreateFolderV2Async("/" + userName.ToLower(), true);
                }

                response = await _dropBoxClient.Files.UploadAsync(@$"/{userName.ToLower()}/{Input.ProfilePicture.FileName}",
                    WriteMode.Overwrite.Instance,
                    body: memoryStream);
            }

            var picturePath = response.PathDisplay;

            return picturePath;
        }

    }
}
