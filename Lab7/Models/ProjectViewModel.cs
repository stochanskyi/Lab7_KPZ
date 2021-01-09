using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {

        }

        public ProjectViewModel(int id, string name, decimal budget, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Budget = budget;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
    }
}
