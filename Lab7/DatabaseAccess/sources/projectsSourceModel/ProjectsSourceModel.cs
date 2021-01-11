using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.DatabaseAccess.sources.projectsSourceModel
{
    public class ProjectsSourceModel : IProjectsSourceModel
    {
        private CompanyManagementContext context;

        public ProjectsSourceModel(CompanyManagementContext context)
        {
            this.context = context;
        }

        public void DeleteProject(int id)
        {
            var projectToDelete = context.Projects.ToList().FirstOrDefault(p => p.ProjectId == id);
            if (projectToDelete == null) throw new Exception();

            context.Projects.Remove(projectToDelete);
            context.SaveChanges();
        }

        public Project FindById(int Id)
        {
            return context.Projects.Find(Id);
        }

        public List<Project> GetProjects()
        {
            return context.Projects.ToList();
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            var projectToUpdate = context.Projects.ToList().FirstOrDefault(p => p.ProjectId == project.ProjectId);
            if (projectToUpdate == null) throw new Exception();

            projectToUpdate.ProjectName = project.ProjectName;
            projectToUpdate.Budget = project.Budget;
            projectToUpdate.Description = project.Description;

            context.SaveChanges();
        }
    }
}
