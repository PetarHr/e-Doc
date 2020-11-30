using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace eDoc.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="Моля, въведете е-поща.")]
            [EmailAddress(ErrorMessage ="Моля, въведете валидна е-поща.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Моля, въведете име.")]
            [Display(Name = "Име")]
            [StringLength(100, ErrorMessage ="Името трябва да е между {1} и {2} символа.", MinimumLength =2)]
            public string FirstName { get; set; }

            [Required(ErrorMessage ="Моля, въведете презиме.")]
            [Display(Name = "Презиме")]
            [StringLength(100, ErrorMessage = "Презимето трябва да е между {1} и {2} символа.", MinimumLength = 2)]
            public string FathersName { get; set; }

            [Required(ErrorMessage = "Моля, въведете фамилия.")]
            [Display(Name = "Фамилия")]
            [StringLength(100, ErrorMessage = "Фамилията трябва да е между {1} и {2} символа.", MinimumLength = 2)]
            public string FamilyName { get; set; }
            public Title Title { get; set; }
            public string FullName => this.FirstName + " " + this.FathersName + " " + this.FamilyName;
            public string PIN { get; set; }
            public DateTime BirthDate { get; set; }
            public Sex Sex { get; set; }
            public Workplace Workplace { get; set; }
            public string Occupation { get; set; }
            public string UIN { get; set; }
            public string SpecialtyCode { get; set; }
            public MedicalCenter MedicalCenter { get; set; }
            public string Role { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new {ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor : true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                ProviderDisplayName = info.ProviderDisplayName;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.Name),
                        FathersName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                        FamilyName = info.Principal.FindFirstValue(ClaimTypes.Surname)
                    };
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                if (!IsPINValid(Input.PIN))
                {
                    ModelState.AddModelError("ЕГН", "Моля, въведете валидно ЕГН.");
                    return Page();
                }

                var user = new ApplicationUser
                {
                    Title = Input.Title,
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    FathersName = Input.FathersName,
                    FamilyName = Input.FamilyName,
                    FullName = Input.FullName,
                    PIN = Input.PIN,
                    BirthDate = Input.BirthDate,
                    Sex = Input.Sex,
                    Workplace = Input.Workplace,
                    Occupation = Input.Occupation,
                    UIN = Input.UIN,
                    SpecialtyCode = Input.SpecialtyCode,
                    MedicalCenter = Input.MedicalCenter
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Input.Role);

                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId, code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        // If account confirmation is required, we need to show the link if we don't have a real email sender
                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("./RegisterConfirmation", new { Input.Email });
                        }

                        await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);

                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }
        /// <summary>
        /// Валидира ЕГН според алгоритъма на ЕСГРАО. Благодарности на автора: Драган Драганов (Dr4g0)
        /// </summary>
        /// <param name="personalIDNumber">ЕГН</param>
        /// <returns>True/False дали ЕГН-то е валидно.</returns>
        public static bool IsPINValid(string personalIDNumber)
        {
            if (personalIDNumber.Length != 10)
            {
                return false;
            }
            foreach (char digit in personalIDNumber)
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }
            }
            int month = int.Parse(personalIDNumber.Substring(2, 2));
            int year = 0;
            if (month < 13)
            {
                year = int.Parse("19" + personalIDNumber.Substring(0, 2));
            }
            else if (month < 33)
            {
                month -= 20;
                year = int.Parse("18" + personalIDNumber.Substring(0, 2));
            }
            else
            {
                month -= 40;
                year = int.Parse("20" + personalIDNumber.Substring(0, 2));
            }
            int day = int.Parse(personalIDNumber.Substring(4, 2));
            DateTime dateOfBirth = new DateTime();
            if (!DateTime.TryParse(String.Format("{0}/{1}/{2}", day, month, year), out dateOfBirth))
            {
                return false;
            }
            int[] weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int totalControlSum = 0;
            for (int i = 0; i < 9; i++)
            {
                totalControlSum += weights[i] * (personalIDNumber[i] - '0');
            }
            int controlDigit = 0;
            int reminder = totalControlSum % 11;
            if (reminder < 10)
            {
                controlDigit = reminder;
            }
            int lastDigitFromIDNumber = int.Parse(personalIDNumber[9..]);
            if (lastDigitFromIDNumber != controlDigit)
            {
                return false;
            }
            return true;
        }
    }
}
