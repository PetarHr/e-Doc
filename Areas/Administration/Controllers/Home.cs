using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "GodModeAdmin")]
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
