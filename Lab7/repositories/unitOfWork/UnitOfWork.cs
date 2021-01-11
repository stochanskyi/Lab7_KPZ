using Lab7.DatabaseAccess;
using Lab7.DatabaseAccess.sources.customersSourceModel;
using Lab7.DatabaseAccess.sources.projectsSourceModel;
using Lab7.repositories.customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.repositories.unitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private CompanyManagementContext context;

        private IProjectsSourceModel projectsSourceModel;
        private ICustomersSourceModel customerSourceModel;

        private IProjectsRepository projectsRepo;
        private ICustomersRepository customersRepo;

        public UnitOfWork()
        {
            context = new CompanyManagementContext();
            projectsSourceModel = new ProjectsSourceModel(context);
            customerSourceModel = new CustomerSourceModel(context);
        }

        public IProjectsRepository ProjectsRepository
        {
            get
            {
                if (projectsRepo == null)
                {
                    projectsRepo = new ProjectsRepository(projectsSourceModel);
                }
                return projectsRepo;
            }
        }

        public ICustomersRepository CustomersRepository
        {
            get
            {
                if (customersRepo == null)
                {
                    customersRepo = new CustomersRepository(customerSourceModel);
                }
                return customersRepo;
            }
        }

        private Boolean disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
