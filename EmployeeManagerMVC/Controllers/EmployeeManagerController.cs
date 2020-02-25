using Microsoft.AspNetCore.Mvc;
using EmployeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagerMVC.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private readonly AppDbContext db;

        public EmployeeManagerController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Employee> model = (from e in db.Employees
                                    orderby e.EmployeeID
                                    select e).ToList();
            return View(model);
        }

        private void FillCountries()
        {
            List<SelectListItem> countries =
            (from c in db.Countries
             orderby c.Name ascending
             select new SelectListItem()
             {
                 Text = c.Name,
                 Value = c.Name
             }).ToList();
            ViewBag.Countries = countries;
        }
    }
}
