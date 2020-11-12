using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    public class MyHealthController : Controller
    {
        public async Task<IActionResult> MyHealth()
        {
            //var myData = await _service.GetMyHealthDataAsync();

            return this.View();
        }
    }
}
