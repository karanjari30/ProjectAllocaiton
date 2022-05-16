using AutoMapper;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ProjectRepository : IProjectRepository
    {
        public Karan_SatvaEntities objProject = new Karan_SatvaEntities();
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, Project>());
        public List<GetAllProject_Result1> GetProject(bool? status)
        {
            return objProject.GetAllProject(status).ToList();
        }

        public List<GetProjectById_Result> GetProjectById(int ProjectId)
        {
            return objProject.GetProjectById(ProjectId).ToList();
        }

        public dynamic PostProject(ProjectViewModel model)
        {
            var Projectmapper = config.CreateMapper().Map<Project>(model);
            if (Projectmapper != null)
                 return objProject.InsertUpdateProject(0, Projectmapper.ProjectName, Projectmapper.ProjectDescription, Projectmapper.StartDate, Projectmapper.ProjectStatus, Projectmapper.IsDelete, Projectmapper.IsActive).FirstOrDefault().ID;
            return 0;
        }

        public dynamic PutProject(ProjectViewModel model, int id)
        {
            var Projectmapper = config.CreateMapper().Map<Project>(model);
            if (Projectmapper != null)
                return objProject.InsertUpdateProject(id, Projectmapper.ProjectName, Projectmapper.ProjectDescription, Projectmapper.StartDate, Projectmapper.ProjectStatus, Projectmapper.IsDelete, Projectmapper.IsActive).FirstOrDefault().ID;
            return 0;
        }

        public dynamic DeleteProject(int ProjectId)
        {
            return objProject.DeleteProject(ProjectId);
        }

        public dynamic ProjectStatus(int ProjectId, string ProjectStatus)
        {
            return objProject.ProjectStatus(ProjectId, ProjectStatus);
        }

        public List<ProjectsByEmployeeID_Result> GetProjectsByEmployeeID(int EmployeeId)
        {
            return objProject.ProjectsByEmployeeID(EmployeeId).ToList();
        }
    }
}
