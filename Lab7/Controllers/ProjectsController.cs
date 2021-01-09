using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {

        [HttpGet]
        public ActionResult Get()
        {
            var result = new List<ProjectViewModel>();
            result.Add(new ProjectViewModel(1, "asd", 12, "asdfca"));
            return Ok(result);
        }
    }
}
