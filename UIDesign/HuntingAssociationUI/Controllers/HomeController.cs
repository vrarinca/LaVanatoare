﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HuntingAssociation.Models;

namespace HuntingAssociation.Controllers
{
    public class HomeController : Controller
    {
        
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(UserDTO u){
            
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
