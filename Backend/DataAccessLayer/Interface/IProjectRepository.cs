using DataAccessLayer.Model;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IProjectRepository
    {
        List<GetAllProject_Result1> GetProject(bool? status);
        List<GetProjectById_Result> GetProjectById(int ProjectId);
        dynamic PostProject(ProjectViewModel model);
        dynamic PutProject(ProjectViewModel model, int id);
        dynamic DeleteProject(int ProjectId);
        dynamic ProjectStatus(int ProjectId, string ProjectStatus);
        List<ProjectsByEmployeeID_Result> GetProjectsByEmployeeID(int EmployeeId);
    }
}
