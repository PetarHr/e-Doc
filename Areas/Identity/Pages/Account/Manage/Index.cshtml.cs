using System.Globalization;
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
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Text.RegularExpressions;

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
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [Display(Name = "Профилна снимка")]
        public string ProfilePicture { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Лично име")]
            [StringLength(100, ErrorMessage = "Полето трябва да е между {2} и {1} символа.", MinimumLength = 2)]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Бащино име")]
            [StringLength(100, ErrorMessage = "Полето трябва да е между {2} и {1} символа.", MinimumLength = 2)]
            public string FathersName { get; set; }
            [Required]
            [Display(Name = "Фамилно име")]
            [StringLength(100, ErrorMessage = "Полето трябва да е между {2} и {1} символа.", MinimumLength = 2)]
            public string FamilyName { get; set; }

            [Phone]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }

            public IFormFile ProfilePicture { get; set; }

            [Display(Name = "Дата на раждане")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }
            [Required]
            public string PIN { get; set; }
            [Required]
            public Sex Sex { get; set; }
            public string Occupation { get; set; }
            public string UIN { get; set; }
            public string SpecialtyCode { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userProfile = await _userManager.GetUserAsync(this.User);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userProfile.UserName;

            Input = new InputModel
            {
                FirstName = userProfile.FirstName,
                FathersName = userProfile.FathersName,
                FamilyName = userProfile.FamilyName,
                PhoneNumber = phoneNumber,
                DateOfBirth = userProfile.BirthDate,
                PIN = userProfile.PIN,
                Sex = userProfile.Sex,
                Occupation = userProfile.Occupation,
                UIN = userProfile.UIN,
                SpecialtyCode = userProfile.SpecialtyCode
            };
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Грешка: Не може да се намери профил с име '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Грешка: Не може да се намери профил с име '{_userManager.GetUserId(User)}'.");
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
                    StatusMessage = "Грешка: Възникна неочаквана грешка при промяната на телефонния номер.";
                    return RedirectToPage();
                }
            }

            if (Input.ProfilePicture != null)
            {
                if (
                FormFileExtensions.IsImage(Input.ProfilePicture))
                {

                    user.ProfilePicture = await UploadProfilePictureAsync(user);
                }
                else
                {
                    StatusMessage = "Грешка: Прикачен е невалиден формат за профилна снимка.";
                    return RedirectToPage();
                }
            }


            if (Input.DateOfBirth >= DateTime.Today)
            {
                StatusMessage = "Грешка: Датата на раждане не може да е в бъдеще.";
                return RedirectToPage();
            }

            user.BirthDate = Input.DateOfBirth;
            user.FirstName = Input.FirstName;
            user.FathersName = Input.FathersName;
            user.FamilyName = Input.FamilyName;
            user.FullName = user.FirstName + " " + user.FathersName + " " + user.FamilyName;
            user.Occupation = Input.Occupation;
            user.Sex = Input.Sex;
            user.PIN = Input.PIN;
            user.UIN = Input.UIN;

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

                if (folderList.Entries.Where(f => f.Name == userName.ToLower()).Any())
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
    public static class FormFileExtensions
    {
        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (postedFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using var bitmap = new System.Drawing.Bitmap(postedFile.OpenReadStream());
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                postedFile.OpenReadStream().Position = 0;
            }

            return true;
        }
    }
}
