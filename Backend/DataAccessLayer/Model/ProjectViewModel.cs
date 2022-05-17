using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Constants.Enums;

namespace DataAccessLayer.Model
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
