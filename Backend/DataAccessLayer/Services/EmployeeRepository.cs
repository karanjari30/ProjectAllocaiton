using AutoMapper;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Karan_SatvaEntities objEmployee = new Karan_SatvaEntities();
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, Employee>());

        public List<GetAllEmployee_Result> GetEmployee(bool? status)
        {
            return objEmployee.GetAllEmployee(status).ToList();
        }

        public dynamic PostEmployee(EmployeeViewModel model)
        {
            var Employeemapper = config.CreateMapper().Map<Employee>(model);
            if (Employeemapper != null)
                return objEmployee.InsertUpdateEmployee(0, Employeemapper.EmployeeName, Employeemapper.EmailAddress, Employeemapper.Phone, Employeemapper.JoinDate, Employeemapper.TotalExperience, Employeemapper.Salary,Employeemapper.IsActive,Employeemapper.IsDelete,Employeemapper.DepartmentId).FirstOrDefault().EmpID;
            return 0;
        }

        public dynamic PutEmployee(EmployeeViewModel model, int id)
        {
            var Employeemapper = config.CreateMapper().Map<Employee>(model);
            if (Employeemapper != null)
                return objEmployee.InsertUpdateEmployee(id, Employeemapper.EmployeeName, Employeemapper.EmailAddress, Employeemapper.Phone, Employeemapper.JoinDate, Employeemapper.TotalExperience, Employeemapper.Salary, Employeemapper.IsActive, Employeemapper.IsDelete, Employeemapper.DepartmentId).FirstOrDefault().EmpID;
            return 0;
        }

        public dynamic EmployeeStatus(int EmployeeId, bool EmployeeStaus)
        {
            return objEmployee.UpdateEmployeeStatus(EmployeeId, EmployeeStaus);
        }


        public List<EmaployeeByProjectID_Result> GetEmployeeByProjectID(int ProjectId)
        {
            return objEmployee.EmaployeeByProjectID(ProjectId).ToList();
        }
    }
}
