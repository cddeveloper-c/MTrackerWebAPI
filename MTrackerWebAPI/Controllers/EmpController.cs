using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace MTrackerWebAPI.Controllers
{

    [ApiController]
    public class EmpController : ControllerBase
    {

        List<Employee> listEmp = new List<Employee>
        {
            new Employee {EmployeeID=1,EmployeeName="test", Address="test", Company_name="cts",  Designation="soft1"},
            new Employee {EmployeeID=2,EmployeeName="Sarna", Address="rbh", Company_name="tcs",  Designation="sde"},
            new Employee {EmployeeID=3,EmployeeName="Rahul", Address="dgp", Company_name="accenture",  Designation="dba"},
            new Employee {EmployeeID=4,EmployeeName="Mondal", Address="png", Company_name="tier5",  Designation="dba"},
            new Employee {EmployeeID=5,EmployeeName="Deep", Address="city", Company_name="ibm",  Designation="soft"}
        };

        [HttpGet]
        [Route("api/home/GetAllEmployee")]
        public List<Employee> GetAllEmployee()
        {
            return listEmp;
        }

        [HttpGet]
        [Route("api/home/GetEmployeesById")]
        public Employee GetEmployeesById(int id)
        {
            return listEmp.FirstOrDefault(X => X.EmployeeID == id);
        }

        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<output>>> Getoutput(Input input)
        //{
        //    string StoredProc = "exec CreateAppointment " +
        //            "@ClinicID = " + input.ClinicId + "," +
        //            "@AppointmentDate = '" + input.AppointmentDate + "'," +
        //            "@FirstName= '" + input.FirstName + "'," +
        //            "@LastName= '" + input.LastName + "'," +
        //            "@PatientID= " + input.PatientId + "," +
        //            "@AppointmentStartTime= '" + input.AppointmentStartTime + "'," +
        //            "@AppointmentEndTime= '" + input.AppointmentEndTime + "'";

        //    //return await _context.output.ToListAsync();
        //    return await _context.output.FromSqlRaw(StoredProc).ToListAsync();
        //}

    }
    
}
