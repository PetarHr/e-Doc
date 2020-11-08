﻿using eDoc.Data.Models;
using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService service;
        private readonly UserManager<ApplicationUser> userManager;

        public PatientController(IPatientService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public IActionResult MyRecipes()
        {
            var userId = userManager.GetUserId(this.User);

            var myRecipesList = service.GetMyRecipes(userId);

            return View(myRecipesList);
        }
        public IActionResult RecipeDetails(string id)
        {
             var recipeDetails = service.GetRecipeDetails(id);

            return View(recipeDetails);
        }

        public IActionResult MyAmbulatoryLists()
        {
            var userId = userManager.GetUserId(this.User);

            var myAmbulatoryLists = service.GetMyAmbulatoryLists(userId);

            return View(myAmbulatoryLists);
        }

        public IActionResult MyDoctor()
        {
            var userId = userManager.GetUserId(this.User);

            var myDoctor = service.GetMyDoctor(userId);

            if (myDoctor == null)
            {
                return View("MissingDoctor");
            }
            return this.View(myDoctor);
        }
    }
}
