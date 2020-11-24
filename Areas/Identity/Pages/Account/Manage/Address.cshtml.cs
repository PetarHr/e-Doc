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

namespace eDoc.Areas.Identity.Pages.Account.Manage
{
    public partial class AddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public AddressModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
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

            [Display(Name = "Адрес")]
            public Address UserAddress { get; set; }

            public List<string> CountryList { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userProfile = await _userManager.GetUserAsync(this.User);
       
            var userAddress = this._db.Addresses.Where(x => x.Id == userProfile.AddressId).FirstOrDefault();

            if (userAddress != null)
            {
                userAddress.Country = this._db.Countries.Where(x => x.Id == userProfile.Address.CountryId).FirstOrDefault();
                userAddress.Region = this._db.Regions.Where(x => x.Id == userProfile.Address.RegionId).FirstOrDefault();
                userAddress.Municipality = this._db.Municipalities.Where(x => x.Id == userProfile.Address.MunicipalityId).FirstOrDefault();
            }

            Input = new InputModel
            {
                UserAddress = userAddress,
                CountryList = GetCountryList()
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

            if (Input.UserAddress != null)
            {
                UpdateUserAddress(user);
            }

            this._db.Users.Update(user);
            await this._db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = $"Адресът е обновен успешно.";
            return RedirectToPage();
        }

        private void UpdateUserAddress(ApplicationUser user)
        {
            var dbCountryList = this._db.Countries.Select(x => x.Name).ToList();
            var dbRegionList = this._db.Regions.Select(x => x.Name).ToList();
            var dbMunicipalityList = this._db.Municipalities.Select(x => x.Name).ToList();
            var dbUserAddress = this._db.Addresses.Where(x => x.Id == user.AddressId).FirstOrDefault();

            if (dbUserAddress == null)
            {
                user.Address = Input.UserAddress;
            }
            else
            {
                user.Address = dbUserAddress;
                user.Address.Apartment = Input.UserAddress.Apartment;
                user.Address.City = Input.UserAddress.City;
                user.Address.Comment = Input.UserAddress.Comment;
                user.Address.Entrance = Input.UserAddress.Entrance;
                user.Address.Floor = Input.UserAddress.Floor;
                user.Address.Street = Input.UserAddress.Street;
                user.Address.StreetNumber = Input.UserAddress.StreetNumber;
                user.Address.Country = Input.UserAddress.Country;
                user.Address.Region = Input.UserAddress.Region;
                user.Address.Municipality = Input.UserAddress.Municipality;
            }

            if (dbCountryList.Contains(Input.UserAddress.Country.Name))
            {
                user.Address.Country = this._db.Countries.Where(x => x.Name == Input.UserAddress.Country.Name).FirstOrDefault();
            }

            if (dbRegionList.Contains(Input.UserAddress.Region.Name))
            {
                user.Address.Region = this._db.Regions.Where(x => x.Name == Input.UserAddress.Region.Name).FirstOrDefault();
            }

            if (dbMunicipalityList.Contains(Input.UserAddress.Municipality.Name))
            {
                user.Address.Municipality = this._db.Municipalities.Where(x => x.Name == Input.UserAddress.Municipality.Name).FirstOrDefault();
            }
        }

        private List<string> GetCountryList()
        {
            this.Input = new InputModel
            {
                CountryList = new List<string>()
            };

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var culture in cultureInfos)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(Input.CountryList.Contains(string.Concat((region.DisplayName), $" ({region.ThreeLetterISORegionName})"))))
                {
                    Input.CountryList.Add(string.Concat((region.DisplayName), $" ({region.ThreeLetterISORegionName})"));
                }
            }

            Input.CountryList.Sort();

            return Input.CountryList;
        }

    }
}
