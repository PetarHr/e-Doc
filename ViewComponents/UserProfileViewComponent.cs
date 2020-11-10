using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View_Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public UserProfileViewComponent(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string user)
        {
            var userProfile = await userManager.FindByIdAsync(user);
            var userRole = userManager.GetRolesAsync(userProfile).GetAwaiter().GetResult().FirstOrDefault();

            var viewModel = new UserProfileViewModel
            {
                FirstName = userProfile.FirstName,
                FamilyName = userProfile.FamilyName,
                Role = userRole
            };

            return View(viewModel);
        }
    }
}
