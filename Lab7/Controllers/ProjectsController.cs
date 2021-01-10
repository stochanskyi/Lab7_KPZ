using Lab7.DatabaseAccess;
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

        private CompanyManagementContext context;

        public ProjectsController(CompanyManagementContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(context.Projects.ToList().Select(p => toViewModel(p)));
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel project)
        {
            var pr = new Project
            {
                ProjectName = project.Name,
                Budget = project.Budget,
                StatusId = 1,
                Description = project.Description,
                CustId = 2
            };

            context.Projects.Add(pr);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult Update(ProjectViewModel project)
        {
            var projectToUpdate = context.Projects.ToList().FirstOrDefault(p => p.ProjectId == project.Id);
            if (projectToUpdate == null) return NotFound("project with specified ID cannot be found");

            projectToUpdate.ProjectName = project.Name;
            projectToUpdate.Budget = project.Budget;
            projectToUpdate.Description = project.Description;

            context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var projectToDelete = context.Projects.ToList().FirstOrDefault(p => p.ProjectId == id);
            if (projectToDelete == null) return NotFound();

            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            return Ok();
        }

        private ProjectViewModel toViewModel(Project project)
        {
            return new ProjectViewModel(project.ProjectId, project.ProjectName, (decimal)project.Budget, project.Description);
        }
    }
}