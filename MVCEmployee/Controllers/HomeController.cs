using Microsoft.AspNetCore.Mvc;
using MVCEmployee.Models;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;

namespace MVCEmployee.Controllers
{
    //Controller class.
    public class HomeController : Controller
    {
        //Creating of list and count of employees.
        public static List<Employee> List1 = new List<Employee> ();
        public static int count=0;
        
        public ActionResult Index()
        {
            ViewBag.List = List1;
            return View();
        }
        public ActionResult Add()
        {            
            ViewBag.List = List1;
            return View();
        }
        public ActionResult Remove()
        { 
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        //Handling of HTTP POST methods employee manipulation.
        [HttpPost]
        
        public ActionResult Add(Models.Employee employee)
        {
            //Counting menbers with count.
            employee.ID = count;
            count++;
            List1.Add(employee);
            return View("Employees", employee);
        }
        //Handling removing of employee via POST HTTP method.
        [HttpPost]
        public ActionResult Remove(int ID)
        {            
            try {
                List1.RemoveAll(e => e.ID == ID);
            }
            catch {
                return View("Failure");
            }
            return View("Successful");
        }
        //Handlig unpdating of employee via POST HTTP method.
        [HttpPost]
        public ActionResult Update(Models.Employee employee)
        {
            
            foreach(Employee i in List1)
            {
            if (employee.ID>count)
            {
                return View("Failure");     
            }
                if(employee.ID == i.ID)
                {
                    i.Name = employee.Name;
                    i.Email= employee.Email;
                    i.Phone = employee.Phone;
                    break;
                }
            }
            return View("Successful");
        }

    }
}