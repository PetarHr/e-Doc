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
    public partial class WorkplaceModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public WorkplaceModel(
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

            [Display(Name = "Работодател")]
            public Workplace MyWorkplace { get; set; }

            public List<string> CountryList { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userProfile = await _userManager.GetUserAsync(this.User);
       
            Input = new InputModel
            {
                MyWorkplace = userProfile.Workplace,
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

            if (user.Workplace != Input.MyWorkplace)
            {
                user.Workplace = Input.MyWorkplace;

                this._db.Users.Update(user);
                await this._db.SaveChangesAsync();

                StatusMessage = $"Работодателят е обновен успешно.";
                await _signInManager.RefreshSignInAsync(user);
            }

            return RedirectToPage();
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
