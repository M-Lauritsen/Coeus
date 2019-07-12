using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Coeus.Controllers
{
    public class ProjectController : Controller
    {
        [Route("Chat")]
        public IActionResult Chat()
        {
            return View();
        }
    }
}