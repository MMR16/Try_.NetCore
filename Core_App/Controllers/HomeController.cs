using Core_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_App.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext DB;
        public HomeController(CompanyContext context)
        {
            DB = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(DB.Employees.Include(q => q.Department).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DeptId = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName", 1);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DeptId = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName",e.DeptId);
                return View();
            }
            DB.Add(e);
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var emp = DB.Employees.Any(w=>w.Id ==id);
            if (emp)
            {
                var em = DB.Employees.Find(id);
                DB.Employees.Remove(em);
                DB.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
         
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var emp = DB.Employees.Any(w => w.Id == id);
            if (emp)
            {
                var em = DB.Employees.Find(id);
                ViewBag.DeptId = new SelectList(DB.Departments, "DeptId", "DeptName", em.DeptId);
                return View(em);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DeptId = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName", e.DeptId);
                return View();
            }
            DB.Entry(e).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var emp = DB.Employees.Any(w => w.Id == id);
            if (emp)
            {
                var em = DB.Employees.Find(id);
                ViewBag.DeptId = new SelectList(DB.Departments, "DeptId", "DeptName", em.DeptId);
                return View(em);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
