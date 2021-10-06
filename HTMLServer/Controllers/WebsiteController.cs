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
    public class WebsiteController : ControllerBase
    {
        [HttpGet]
        public List<HTMLObjects> Get()
        {
            var data = new DataAccess.Database();
            return data.Objects.Include(obj => obj.options).ToList();
        }

        [Route("Add/{id}")]
        [HttpGet]
        public List<HTMLObjects> Add(string id)
        {
            new Logic.ObjectLogic().CreateObject(id, new HTMLObjects());
            
            return null;
        }
    }
}
