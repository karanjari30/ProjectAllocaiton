using Core.CommanFunctions;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Services;
using ProjectAllocationAPI.Models;
using System;
using System.Linq;
using System.Web.Http; 

namespace ProjectAllocationAPI.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        public Karan_SatvaEntities objEmployee = new Karan_SatvaEntities();
        static readonly IEmployeeRepository EmployeeRepository = new EmployeeRepository();

        public JsonResponse GetEmployee(bool? status)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var Employeelist = EmployeeRepository.GetEmployee(status);
                if (Employeelist.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + Employeelist.Count, Employeelist);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", Employeelist);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }

        [HttpPost]
        public JsonResponse PostEmployee(EmployeeViewModel model)
        {
            var objResponse = new JsonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    var objEmployee = EmployeeRepository.PostEmployee(model);
                    objResponse = JsonResponseHelper.JsonMessage(1, "Record Created Successfully", objEmployee);
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

        public JsonResponse PutEmployee(int id,EmployeeViewModel model)
        {
            var objResponse = new JsonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    if (objEmployee.Employees.Find(id) != null)
                    {
                        model.EmployeeId = id;
                        var objEmployee = EmployeeRepository.PutEmployee(model, id);
                        objResponse = JsonResponseHelper.JsonMessage(1, "Record Updated Successfully", objEmployee);
                    }
                    else
                        objResponse = JsonResponseHelper.JsonMessage(2, "No Record found", null);
                }
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ModelState.Values.SelectMany(E => E.Errors).Select(E => E.ErrorMessage).ToList());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.InnerException.Message);
                else
                    objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        [Route("api/UpdateEmployeeStatus")]
        public JsonResponse PatchEmployeeStatus(int id, bool EmployeeStatus)
        {
            var objResponse = new JsonResponse();
            try
            {
                if(objEmployee.Employees.Find(id) != null)
                    objResponse = JsonResponseHelper.JsonMessage(1, "Status updated successfully.", EmployeeRepository.EmployeeStatus(id,EmployeeStatus));
                else
                    objResponse = JsonResponseHelper.JsonMessage(2, "Record Not Found.", null);
            }
            catch (Exception ex)
            {
                objResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objResponse;
        }

        [Route("api/GetEmployeeByProjectId")]
        public JsonResponse GetEmployeeByProjectId(int ProjectId)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var EmployeeByProjectID = EmployeeRepository.GetEmployeeByProjectID(ProjectId);
                if (EmployeeByProjectID.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + EmployeeByProjectID.Count, EmployeeByProjectID);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", EmployeeByProjectID);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }
    }
}
