using Lab7.DatabaseAccess;
using Lab7.DatabaseAccess.sources.projectsSourceModel;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.repositories
{
    public class ProjectsRepository : IProjectsRepository
    {

        private IProjectsSourceModel sourceModel;

        public ProjectsRepository(IProjectsSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        public void CreateProject(ProjectViewModel model)
        {
            sourceModel.InsertProject(ToDataModel(model));
        }

        public void DeleteProject(int id)
        {
            sourceModel.DeleteProject(id);
        }

        public List<ProjectViewModel> GetProjects()
        {
            return sourceModel.GetProjects().Select(p => toViewModel(p)).ToList();
        }

        public void UpdateProject(ProjectViewModel model)
        {
            sourceModel.UpdateProject(ToDataModel(model));
        }

        private ProjectViewModel toViewModel(Project project)
        {
            return new ProjectViewModel(project.ProjectId, project.ProjectName, (decimal)project.Budget, project.Description);
        }

        private Project ToDataModel(ProjectViewModel project)
        {
            return new Project {
                ProjectName = project.Name,
                Budget = project.Budget,
                StatusId = 1,
                Description = project.Description,
                CustId = 2
            };
        }

        public ProjectViewModel GetById(int Id)
        {
            return toViewModel(sourceModel.FindById(Id));
        }
    }
}
