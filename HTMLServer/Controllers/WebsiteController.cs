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
        public async Task CreateWebsite(string url) {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            Logic.CreateWebsite(url, ownerId);
        }

        public WebsiteController() {
            Logic = new WebsiteLogic();
        }
    }
}
