using Ado.NetCrudWith_Procedure.DAL;
using Ado.NetCrudWith_Procedure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Ado.NetCrudWith_Procedure.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly Employee_DL _employeeDL;

        public ApplicationController(IConfiguration configuration)
        {
            _employeeDL = new Employee_DL(configuration);
        }

        public IActionResult Index()
        {
            var employees = _employeeDL.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _employeeDL.InsertEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var employee = _employeeDL.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _employeeDL.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _employeeDL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        // You can add other action methods as needed
    }
}
