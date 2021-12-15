using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace HTMLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly Logic.ObjectLogic ObjectLogic;
        public ObjectController(DataAccess.Database db) {
            ObjectLogic = new Logic.ObjectLogic(db);
        }

        [Route("create/{pageId}/{type}")]
        [HttpGet]
        public string CreateObject(string pageId, int type)
        {
            ObjectLogic.CreateObject(pageId, new HTMLObjects(), type);
            return "test";
        }

        [Route("delete/{key}")]
        [HttpGet]
        public string DeleteObject(string key)
        {
            ObjectLogic.DeleteObject(key);
            return "yeet";
        }

        [Route("addchild/{key}")]
        [HttpGet]
        public string AddChild(string key)
        {
            ObjectLogic.AddObjectToParent(key, new HTMLObjects() {key = "pipoban" });
            return "yeet";
        }

        [Route("changeParent/{pageId}/{objectKey}/{newParentKey}")]
        [HttpGet]
        public string ChangeParent(string pageId, string objectKey, string newParentKey)
        {
            ObjectLogic.ChangeObjectParent(pageId, objectKey, newParentKey);
            return "yeet";
        }

        [Route("editOptions")]
        [HttpPost]
        public string EditOptions([FromBody] Options options)
        {
            ObjectLogic.EditObjectOptions(options);
            return "yeet";
        }

    }
}
