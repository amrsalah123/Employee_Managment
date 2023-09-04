using infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using BusinessLogic;
namespace peresentation.Controllers
{
    public class HomeController : Controller
    {
      //  private readonly AppDbContext _AppDbContext;
        private readonly IEmployeeRepository employeeRepository; 
        public HomeController(IEmployeeRepository _employeeRepository)
        {
        //    _AppDbContext = appDbContext;
            employeeRepository = _employeeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await employeeRepository.Get_All();
            // var data =await _AppDbContext.employees.ToListAsync();
            return View(data);   
        }
        [HttpGet]
        public IActionResult create()
        {
            List<String> list = new List<string>() {
            "It","Testing","Automation","Developement","Devops"
            };
            ViewBag.dep = list;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(employee em)
        {
            if (ModelState.IsValid)
            {
                await employeeRepository.Create(em);
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                List<String> list = new List<string>() {
               "It","Testing","Automation","Developement","Devops"
                };
                ViewBag.dep = list;
                return View(em);

            }
          
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await employeeRepository.get(id);
            if (emp == null)
                RedirectToAction(nameof(Index));
            List<String> list = new List<string>() {
               "It","Testing","Automation","Developement","Devops"
                };
            ViewBag.dep = list;

            return View(emp); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(employee emp)
        {
            if (ModelState.IsValid)
            {

                await employeeRepository.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }
        public async Task<IActionResult> details(int id)
        {
            var emp = await employeeRepository.get(id);
            if (emp == null)
                return RedirectToAction(nameof(Index));
            return View(emp);

        }
        /*No Need*/
        //public async Task<IActionResult> delete(int id)
        //{
        //    var emp = await _AppDbContext.employees.FindAsync(id);
        //    if (emp == null)
        //        return RedirectToAction(nameof(Index));
        //    return View(emp);

        //}
        public async Task<IActionResult> del(int id)
        {
            var emp = await employeeRepository.get(id);
            if (emp != null)
            {
              await employeeRepository.Delete(emp);
             
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Search(string emp_search)
        {
            var list = employeeRepository.SearchByName(emp_search);
          //  var b =await employeeRepository.Get_All();
            return PartialView("_emp_search", list);
              
        }


    }
}
