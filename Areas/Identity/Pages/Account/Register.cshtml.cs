using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            public string FirstName { get; set; }
            public string FathersName { get; set; }
            public string FamilyName { get; set; }
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
            public Title Title { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if (!IsPINValid(Input.PIN))
                {
                    ModelState.AddModelError("ЕГН:", "Моля, въведете валидно ЕГН.");
                    return Page();
                }
                    var user = new ApplicationUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        Title = Input.Title,
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
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    await _userManager.AddToRoleAsync(user, Input.Role);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code, returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
            }

            // If we got this far, something failed, redisplay form
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
