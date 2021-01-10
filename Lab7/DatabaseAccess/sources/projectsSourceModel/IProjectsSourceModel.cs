using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.DatabaseAccess.sources.projectsSourceModel
{
    public interface IProjectsSourceModel
    {
        List<Project> GetProjects();

        void UpdateProject(Project project);
        void DeleteProject(int id);
        void InsertProject(Project project);

    }
}