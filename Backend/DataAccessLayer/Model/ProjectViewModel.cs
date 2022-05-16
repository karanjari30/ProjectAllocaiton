using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public string ProjectStatus { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
