﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationLab.Controllers {
    public class AccountController : Controller {
        // GET: /<controller>/
        public async Task<IActionResult> Login() {
            return View();
        }

        public async Task<IActionResult> Forbidden() {
            return View();
        }
    }
}
