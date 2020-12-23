using Core_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_App.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext DB;
        public DepartmentController(CompanyContext context)
        {
            DB = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
