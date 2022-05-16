using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Services;
using ProjectAllocationAPI.Helper;
using ProjectAllocationAPI.Models;

namespace ProjectAllocationAPI.Controllers
{
    public class ProjectController : ApiController
    {
        public Karan_SatvaEntities objProject = new Karan_SatvaEntities();
        static readonly IProjectRepository projectRepository = new ProjectRepository();

        public JsonResponse GetProject(bool? status)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var Projectlist = projectRepository.GetProject(status);
                if (Projectlist.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + Projectlist.Count, Projectlist);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", Projectlist);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }
        [Route("~/ProjectByID")]
        public JsonResponse GetProjectById(int ProjectId)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var Projectbyid = projectRepository.GetProjectById(ProjectId);
                if (Projectbyid.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + Projectbyid.Count, Projectbyid);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", Projectbyid);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }

        [HttpPost]
        public JsonResponse PostProject(ProjectViewModel model)
        {
            var objResponse = new JsonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    var objproject = projectRepository.PostProject(model);
                    objResponse = JsonResponseHelper.JsonMessage(1, "Record Created Successfully", objproject);
                }
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ModelState.Values.SelectMany(E => E.Errors).Select(E => E.ErrorMessage).ToList());
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.InnerException.Message);
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        public JsonResponse PutProject(int id, ProjectViewModel model)
        {
            var objResponse = new JsonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    if (objProject.Projects.Find(id) != null)
                    {
                        model.ProjectId = id;
                        var objproject = projectRepository.PutProject(model, id);
                        objResponse = JsonResponseHelper.JsonMessage(1, "Record Updated Successfully", objproject);
                    }
                    else
                        objResponse = JsonResponseHelper.JsonMessage(2, "No Record found", null);
                }
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ModelState.Values.SelectMany(E => E.Errors).Select(E => E.ErrorMessage).ToList());
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.InnerException.Message);
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        [Route("~/DeleteProjectByID")]
        public JsonResponse PatchProjectRemove(int id)
        {
            var objResponse = new JsonResponse();
            try
            {
                var objProjectData = objProject.DeleteProject(id).FirstOrDefault().result;
                if (objProjectData == 1)
                    objResponse = JsonResponseHelper.JsonMessage(1, "Project deleted successfully.", objProjectData);
                else if (objProjectData == 2)
                    objResponse = JsonResponseHelper.JsonMessage(1, "Project can not completed yet", objProjectData);
                else
                    objResponse = JsonResponseHelper.JsonMessage(2, "Record Not Found.", null);
            }
            catch (Exception ex)
            {
                objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        [Route("~/UpdateProjectStatus")]
        public JsonResponse PatchProjectStatus(int id, string ProjectStatus)
        {
            var objResponse = new JsonResponse();
            try
            {
                var objProjectStatus = objProject.ProjectStatus(id, ProjectStatus).FirstOrDefault().Result;
                if (objProjectStatus == 1)
                    objResponse = JsonResponseHelper.JsonMessage(1, "Status updated successfully.", objProjectStatus);
                else if (objProjectStatus == 2)
                    objResponse = JsonResponseHelper.JsonMessage(1, "In project all allocated task is not complete", objProjectStatus);
                else
                    objResponse = JsonResponseHelper.JsonMessage(2, "Record Not Found.", null);
            }
            catch (Exception ex)
            {
                objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        [Route("~/GetProjectsByEmployeeID")]
        public JsonResponse GetProjectsByEmployeeID(int EmployeeId)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var ProjectsByEmployeeID = projectRepository.GetProjectsByEmployeeID(EmployeeId);
                if (ProjectsByEmployeeID.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + ProjectsByEmployeeID.Count, ProjectsByEmployeeID);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", ProjectsByEmployeeID);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }
    }
}