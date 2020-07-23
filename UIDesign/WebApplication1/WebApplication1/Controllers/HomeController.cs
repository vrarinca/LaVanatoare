using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HuntingAssociation.Models;

using HuntingAssociation.Views.DTOs;

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
            // Console.WriteLine(u.user_email);
            // Console.WriteLine(u.user_pass);
            
            if(u.user_email=="admin@yahoo.com" && u.user_pass=="admin"){
                    return RedirectToAction("Index","SysAdmin");
            }

            return Ok();
            
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
