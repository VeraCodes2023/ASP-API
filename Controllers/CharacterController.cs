using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character Knight = new Character();

        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(Knight);
        }
    }
}