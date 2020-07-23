using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Project.Controllers
{   
   [Authorize(Roles="SysAdmin")]
    public class SysAdminController:Controller
    {
        private readonly IUserService _repo;

         public SysAdminController(IUserService repo){
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name, string page_nb)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user_functions = await _repo.getAllUserFunctions();
            User user = await _repo.findById(userId);
            List<PrivateUser> privateUsers = new List<PrivateUser>();
            int usersOnPage = 5;
            List<User> users;
            int userNb = _repo.getNumberOfUsers();
            int pageNb = 0;
            double pages = (double)userNb / usersOnPage;
            int pagesNb = (int)Math.Ceiling(pages);
            int sendCurrent = 1;
            List<int> pageList = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                pageList.Add(i);
            }
            if (name != null)
            {
                users = await _repo.findByName(name);
                for (int i = 0; i < users.Count; i++)
                {
                    PrivateUser u1 = new Library.Data.Models.PrivateUser();
                   // u1.Function = users[i].IdUserFunctionNavigation.FunctionName;
                    u1.Email = users[i].Email;
                    u1.Surname = users[i].Surname;
                    u1.Name = users[i].Name;
                    u1.Cnp = users[i].Cnp;
                    u1.License = users[i].License;
                    u1.Id = users[i].Id;
                    privateUsers.Add(u1);
                }
            }
            else if(page_nb != null)
            {               
                users = await _repo.getAllUser();
                switch (page_nb)
                {
                    case "First":
                        pageNb = 0;
                        break;
                    case "Last":
                        pageNb = pagesNb - 1;
                        break;
                    default:
                        pageNb = Int32.Parse(page_nb) - 1;
                        break;
                }
                sendCurrent = pageNb + 1;
                for (int i = pageNb * usersOnPage; i < pageNb * usersOnPage + usersOnPage && i < userNb; i++)
                {
                    PrivateUser u1 = new Library.Data.Models.PrivateUser();
                    //u1.Function = users[i].IdUserFunctionNavigation.FunctionName;
                    u1.Email = users[i].Email;
                    u1.Surname = users[i].Surname;
                    u1.Name = users[i].Name;
                    u1.Cnp = users[i].Cnp;
                    u1.License = users[i].License;
                    u1.Id = users[i].Id;
                    privateUsers.Add(u1);
                }             
            }
            else{
                users = await _repo.getAllUser();
                for (int i = 0; i < usersOnPage; i++)
                {
                    PrivateUser u1 = new Library.Data.Models.PrivateUser();
                    //u1.Function = users[i].IdUserFunctionNavigation.FunctionName;
                    u1.Email = users[i].Email;
                    u1.Surname = users[i].Surname;
                    u1.Name = users[i].Name;
                    u1.Cnp = users[i].Cnp;
                    u1.License = users[i].License;
                    u1.Id = users[i].Id;
                    privateUsers.Add(u1);
                }

            }
            ViewBag.CurrentPage = sendCurrent;
            ViewBag.LastPage = pagesNb;
            ViewBag.NumberOfPages = pageList;
            ViewData["PrivateUsers"] = privateUsers;
            ViewData["CurrentUser"] = user.Name + " " + user.Surname;
            return View();
        }

        public  IActionResult Users(){
           
            return View();
        }
    }
}