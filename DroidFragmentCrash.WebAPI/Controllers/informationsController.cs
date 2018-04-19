using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroidFragmentCrash.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroidFragmentCrash.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class InformationsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Information> Get()
        {
            return new List<Information>
            {
                new Information { Value = "string1" },
                new Information { Value = "string2" },
                new Information { Value = "string3" }
            };
        }
    }
}
