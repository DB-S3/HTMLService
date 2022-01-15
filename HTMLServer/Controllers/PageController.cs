using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        private readonly Logic.PageLogic PageLogic;
        public PageController(DataAccess.Database db) {
            PageLogic = new Logic.PageLogic(db);
            db.Database.EnsureCreated();
        }


        [Route("AddPage/{name}")]
        [HttpGet, Authorize]
        public async Task<string> AddPage(string name)
        {
            var ownerId = "testOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }

            return await PageLogic.AddPage(name, ownerId);
        }

        [Route("GetPageList")]
        [HttpGet, Authorize]
        public async Task<List<Page>> GetPages()
        {
            var ownerId = "testOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }
            return await PageLogic.GetPages(ownerId);
        }

        [Route("RenamePage/{name}/{pageId}")]
        [HttpGet, Authorize]
        public async Task<string> RenamePage(string name,string pageId)
        {
            var ownerId = "testOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }
            return await PageLogic.RenamePage(pageId, name, ownerId);
        }
        [DisableCors]
        [Route("viewpage/{id}")]
        [HttpGet]
        public async Task<Page> ViewPage(string id)
        {
            return await PageLogic.ViewPage(id);
        }

        [Route("DeletePage/{pageId}")]
        [HttpGet, Authorize]
        public async Task<string> DeletePage(string pageId)
        {
            var ownerId = "testOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }
            return await PageLogic.RemovePage(pageId, ownerId);
        }

        [Route("test")]
        [HttpGet, Authorize]
        public async Task<string> test()
        {
            return await PageLogic.GetDBName();
        }

        [Route("ChangePage")]
        [HttpPost, Authorize]
        public Page ChangePage([FromBody] Page page)
        {
            var ownerId = "testOwnerId";
            if (User.Claims.Count() > 0)
            {
                ownerId = User.Claims.ToList()[1].ToString().Substring(User.Claims.ToList()[1].ToString().LastIndexOf(':') + 1).Trim();
            }
            return PageLogic.ChangePage(page, ownerId);
        }
    }
}
