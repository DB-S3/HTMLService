using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTMLServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly WebsiteLogic Logic;

        [Route("CreateWebsite/{url}/")]
        [HttpGet, Authorize]
        public async Task<string> CreateWebsite(string url) {
            var ownerId = "newTestOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }
            return await Logic.CreateWebsite(url, ownerId);
        }

        public WebsiteController(DataAccess.Database db) {
            Logic = new WebsiteLogic(db);
        }
    }
}
