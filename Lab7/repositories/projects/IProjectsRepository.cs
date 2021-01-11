using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.repositories
{
    public interface IProjectsRepository
    {
        List<ProjectViewModel> GetProjects();

        void CreateProject(ProjectViewModel model);
        void UpdateProject(ProjectViewModel model);
        void DeleteProject(int id);

        ProjectViewModel GetById(int Id);
    }
}
