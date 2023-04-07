using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        List<Customer> listCus = new List<Customer>
        {
            new Customer {Id=1,CName="Rahul", Age=21, CAddress="rajbandh"},
            new Customer {Id=2,CName="Sarna", Age=12, CAddress="Panagarh"},
            new Customer {Id=3,CName="Raj", Age=20, CAddress="Durgapur"},
            new Customer {Id=4,CName="Mondal", Age=25, CAddress="CiryCentre"},
        };
        [HttpGet]
        [Route("api/home/GetAllCustomer")]
        public List<Customer> GetAllCustomer()
        {
            return listCus;
        }
        [HttpGet]
        [Route("api/home/GetCustomersById")]
        public Customer GetCustomerById(int id)
        {
            return listCus.FirstOrDefault(X => X.Id == id);
        }
    }
}
