﻿using Microsoft.AspNetCore.Http;
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
        [Route("create/{pageId}")]
        [HttpGet]
        public string CreateObject(string pageId)
        {
            new Logic.ObjectLogic().CreateObject(pageId, new HTMLObjects() { key = Guid.NewGuid().ToString()});
            return "test";
        }

        [Route("delete/{key}")]
        [HttpGet]
        public string DeleteObject(string key)
        {
            new Logic.ObjectLogic().DeleteObject(key);
            return "yeet";
        }

        [Route("addchild/{key}")]
        [HttpGet]
        public string AddChild(string key)
        {
            new Logic.ObjectLogic().AddObjectToParent(key, new HTMLObjects() {key = "pipoban" });
            return "yeet";
        }

        [Route("changeParent/{pageId}/{objectKey}/{newParentKey}")]
        [HttpGet]
        public string ChangeParent(string pageId, string objectKey, string newParentKey)
        {
            new Logic.ObjectLogic().ChangeObjectParent(pageId, objectKey, newParentKey);
            return "yeet";
        }

        [Route("editOptions")]
        [HttpGet]
        public string EditOptions([FromBody] Options options)
        {
            Console.WriteLine(options.Height);
            new Logic.ObjectLogic().EditObjectOptions(new HTMLObjects() { key= "3234c9ed-baaf-47c2-a7e6-94f8fd0a4b72", options = new Options() {Colour="green", Id="yeet" } });
            return "yeet";
        }

    }
}
