using Common;
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
        [Route("AddPage/{name}/{ownerId}")]
        [HttpGet]
        public void AddPage(string name, string ownerId)
        {
            new Logic.PageLogic().AddPage(name, ownerId);
        }

        [Route("RenamePage/{name}/{pageId}/{ownerId}")]
        [HttpGet]
        public void RenamePage(string name,string pageId, string ownerId)
        {
            new Logic.PageLogic().RenamePage(pageId, name, ownerId);
        }

        [Route("DeletePage/{pageId}/{ownerId}")]
        [HttpGet]
        public void DeletePage(string pageId, string ownerId)
        {
            new Logic.PageLogic().RemovePage(pageId, ownerId);
        }

        [Route("viewpage/{id}")]
        [HttpGet]
        public Page ViewPage(string id)
        {
            return new Logic.PageLogic().ViewPage(id);
        }
    }
}
