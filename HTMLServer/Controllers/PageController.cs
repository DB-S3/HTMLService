using Common;
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
    public class PageController : ControllerBase
    {
        [Route("AddPage/{name}")]
        [HttpGet, Authorize]
        public void AddPage(string name)
        {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            Console.WriteLine(ownerId);
            new Logic.PageLogic().AddPage(name, ownerId);
        }

        [Route("GetPageList")]
        [HttpGet, Authorize]
        public async Task<List<Page>> GetPages()
        {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            return await new Logic.PageLogic().GetPages(ownerId);
        }

        [Route("RenamePage/{name}/{pageId}")]
        [HttpGet, Authorize]
        public void RenamePage(string name,string pageId)
        {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            new Logic.PageLogic().RenamePage(pageId, name, ownerId);
        }

        [Route("viewpage/{id}")]
        [HttpGet]
        public async Task<Page> ViewPage(string id)
        {
            return await new Logic.PageLogic().ViewPage(id);
        }

        [Route("DeletePage/{pageId}")]
        [HttpGet, Authorize]
        public void DeletePage(string pageId)
        {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();

            new Logic.PageLogic().RemovePage(pageId, ownerId);
        }

        [Route("ChangePage")]
        [HttpGet, Authorize]
        public Page ChangePage([FromBody] Page page)
        {
            var ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();

            return new Logic.PageLogic().ChangePage(page, ownerId);
        }
    }
}
