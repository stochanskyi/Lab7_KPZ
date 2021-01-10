using Lab7.DatabaseAccess;
using Lab7.Models;
using Lab7.repositories;
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
        private IProjectsRepository repository;


        public ProjectsController(IProjectsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(repository.GetProjects());
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel project)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(ProjectViewModel project)
        {
            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        private ProjectViewModel toViewModel(Project project)
        {
            return new ProjectViewModel(project.ProjectId, project.ProjectName, (decimal)project.Budget, project.Description);
        }
    }
}