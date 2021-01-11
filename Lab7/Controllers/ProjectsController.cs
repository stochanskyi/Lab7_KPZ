using Lab7.DatabaseAccess;
using Lab7.Models;
using Lab7.repositories;
using Lab7.repositories.unitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectsRepository repository
        {
            get
            {
                return uow.ProjectsRepository;
            }
        }

        private UnitOfWork uow;

        public ProjectsController(UnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(repository.GetProjects());
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel project)
        {
            repository.CreateProject(project);
            return Ok();
        }

        [HttpGet("/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpPut]
        public ActionResult Update(ProjectViewModel project)
        {
            repository.UpdateProject(project);
            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            repository.DeleteProject(id);
            return Ok();
        }
    }
}