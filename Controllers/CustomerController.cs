using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFluentValidationDemo.Models;
using AspNetCoreFluentValidationDemo.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFluentValidationDemo.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            } 

            //TODO: Save the customer to the database.

            return Ok();
        }
    }
}
