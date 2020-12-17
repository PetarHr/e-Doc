using eDoc.Data;
using eDoc.Models.View.API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace eDoc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MKBListController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MKBListController (ApplicationDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public List<MKBViewModel> GetMKBDetails(string searchText)
        {
            List<MKBViewModel> MKBFilteredList = this._db.MKBDiagnoses
                                                         .Where(x => x.Code.Contains(searchText) || x.Description.Contains(searchText))
                                                         .Select(y => new MKBViewModel 
                                                         {
                                                             MKBId = y.Id,
                                                             MKBCode = y.Code, 
                                                             MKBDescription = y.Description
                                                         })
                                                         .ToList();

            return MKBFilteredList;
        }
    }
}
