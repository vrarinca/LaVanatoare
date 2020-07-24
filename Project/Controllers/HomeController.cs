using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models;
// using Library.Data.Models;
using Library.Web.Models.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.DTOs;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUserService _repo;
        private readonly IAssociationService _assoc;
        public HomeController(IUserService repo, IAssociationService assoc){
            this._repo = repo;
            this._assoc = assoc;
        }
        
        public IActionResult Index()
        {   
            
            if(!HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role)){
                return View();
            }
            
            string currentRole=HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            

            if (currentRole.Equals("SysAdmin"))
            {
                return RedirectToAction("Index", "SysAdmin");
            }
            else if (currentRole.Equals("AssocAdmin"))
            {
                return RedirectToAction("Index","AsocAdmin");
            }
            else if (currentRole.Equals("Operator"))
            {
                return RedirectToAction("Index","Operator");
            }
            
            return View();
            
        }

        public IActionResult ErrorLoggingIn()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost("chooseAsoc")]
        public async Task<IActionResult> ChooseAss(string assoc_name)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            string rememberMeStr = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData).Value;
            bool rememberMe;
            if(rememberMeStr == "True")
            {
                rememberMe = true;
            }
            else
            {
                rememberMe = false;
            }
            Library.Data.Models.User user = await _repo.findById(userId);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            List<UserAssociation> associations = await _assoc.getAllUserAss(userId);
            UserAssociation currentUserAssociation = new UserAssociation();
            int i = 0;
            foreach (UserAssociation uA in associations)
            {
                string name = await _assoc.getAssociationNameById(uA.Id);
                if(name == assoc_name)
                {
                    currentUserAssociation = associations[i];
                    break;
                }
                i++;
            }
            int role = (int)currentUserAssociation.IdRole;
            string rol = "Operator";
            if (role == 1)
            {
                rol = "SysAdmin";
            }
            else if (role == 2)
            {
                rol = "AssocAdmin";
            }
            else if (role == 3)
            {
                rol = "Operator";
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, rol),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.UserData, currentUserAssociation.IdAssociation.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(300),
                IsPersistent = rememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            if (role == 1)
            {
                return RedirectToAction("Index", "SysAdmin");
            }
            else if (role == 2)
            {
                return RedirectToAction("Index", "AsocAdmin");
            }
            else if (role == 3)
            {
                return RedirectToAction("Index", "Operator");
            }

            return RedirectToAction("ErrorLoggingIn");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email_login, string pass_login, bool remember_me)
        {
            var user = await _repo.Login(email_login, pass_login);
            if (user == null)
            {
                return RedirectToAction("ErrorLoggingIn");
            }
            List<UserAssociation> associations = await _assoc.getAllUserAss(user.Id);

            if (associations.Count != 1)
            {
                List<string> asocNames = new List<string>();
                foreach (UserAssociation uA in associations)
                {
                    string name = await _assoc.getAssociationNameById(uA.Id);
                    asocNames.Add(name);
                }
                List<Claim> claimss = new List<Claim>
                {
                new Claim(ClaimTypes.Name, email_login),
                new Claim(ClaimTypes.UserData, remember_me.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                var identityy = new ClaimsIdentity(claimss, CookieAuthenticationDefaults.AuthenticationScheme);
                var principall = new ClaimsPrincipal(identityy);
                var propss = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(300),
                    IsPersistent = remember_me
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principall, propss);

                ViewBag.AssNumber = associations.Count;
                ViewBag.Association = asocNames;
                return View("ChooseAss");
            }
            int role = (int)associations[0].IdRole;
            string rol = "Operator";
            if (role == 1)
            {
                rol = "SysAdmin";
            }
            else if (role == 2)
            {
                rol = "AssocAdmin";
            }
            else if (role == 3)
            {
                rol = "Operator";
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email_login),
                new Claim(ClaimTypes.Role, rol),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.UserData, associations[0].IdAssociation.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(300),
                IsPersistent = remember_me
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            if (role == 1)
            {
                return RedirectToAction("Index", "SysAdmin");
            }
            else if (role == 2)
            {
                return RedirectToAction("Index", "AsocAdmin");
            }
            else if (role == 3)
            {
                return RedirectToAction("Index", "Operator");
            }
            return RedirectToAction("ErrorLoggingIn");
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }


        /*
        [HttpGet("admin")]
        public async Task<IActionResult> Index(int userId)
        {
            var user = await _repo.findById(userId);

            var model = new Library.Web.Models.Login.User
            {
                Email = user.Email,
                Cnp = user.Cnp,
                Password = user.Password,
                Insurance = user.Insurance,
                License = user.License,
                Name = user.Name,
                Surname = user.Surname
            };
            return View(model);
        }

        */
        

        

       
        
    }
}
