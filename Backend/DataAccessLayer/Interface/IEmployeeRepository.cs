using DataAccessLayer.Model;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeRepository
    {
        List<GetAllEmployee_Result> GetEmployee(bool? status);
        dynamic PostEmployee(EmployeeViewModel model);
        dynamic PutEmployee(EmployeeViewModel model, int id);
        dynamic EmployeeStatus(int EmployeeId, bool EmployeeStaus);
        List<EmaployeeByProjectID_Result> GetEmployeeByProjectID(int ProjectId);
    }
}
