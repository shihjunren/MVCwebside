using Microsoft.AspNetCore.Mvc;
using MVCwebside.Models;
using System.Xml.Linq;

namespace MVCwebside.Controllers
{
    public class AjaxController : Controller
    {
        private readonly NorthwindContext _context;
        public AjaxController(NorthwindContext context)
        {
            _context = context;
        }
        [HttpGet()]
        public string Greet(string Name) 
        { 
            return $"Hello,{Name}!"; 
        }
        [HttpPost(), ActionName("Greet")]
        public string PostGreet(string Name)
        {
            return $"Hello,{Name}!";
        }
        [HttpPost()]
        public string FetchPostGreet([FromBody] Parameter p) 
        {
            return $"Hello,{p.Name}!";
        }

        [HttpPost]
        public string CheckName(string FirstName)
        {
            bool Exists = _context.Employees.Any( e=>e.FirstName == FirstName );
            return Exists ? "true" : "false";
        }
        [HttpPost]
        public string FetchCheckName([FromBody] Employees emp)
        {
            bool Exists = _context.Employees.Any(e=>e.FirstName == emp.FirstName);
            return Exists ? "true" : "false";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
