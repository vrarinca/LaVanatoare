using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models;
using Library.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Authorize(Roles= "AssocAdmin")]
    public class AsocAdminController:Controller
    {
        private readonly IUserService _repo;
        private readonly IAssociationService _assoc;
        //private readonly IHuntingGroundsService _serv;

        public AsocAdminController(IUserService repo, IAssociationService assoc)
        {
            _repo = repo;
            _assoc = assoc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int userId=Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            int idAssociation = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData).Value);
            User user= await _repo.findById(userId);
            //Association association = _assoc.GetAssociations().FirstOrDefault(x => x.Id == userId);
            List<UserAssociation> userAssociations = _assoc.GetUserAssociations().Where(x => x.IdAssociation == idAssociation).ToList();
            List<User> users = new List<User>();
            foreach(UserAssociation ua in userAssociations)
            {
                User userAux = await _repo.findById((int)ua.IdUser);
                users.Add(userAux);
            }
            List<PrivateUser> privateUsers= new List<PrivateUser>();
            int usersOnPage = 5;
            for (int i = 0; i < usersOnPage; i++)
            {
                PrivateUser u1 = new Library.Data.Models.PrivateUser();
                u1.Email = users[i].Email;
                u1.Surname = users[i].Surname;
                u1.Name = users[i].Name;
                u1.Cnp = users[i].Cnp;
                u1.License = users[i].License;
                u1.Id = users[i].Id;
                privateUsers.Add(u1);
            }

            ViewData["PrivateUsers"] = privateUsers;
            ViewData["CurrentUser"]=user.Name+" "+user.Surname;
            return View();
        }

        //[HttpPost("findUserAsoc")]
        //public async Task<IActionResult> Edits(string name)
        //{
        //    int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        //    var user_functions = await _repo.getAllUserFunctions();
        //    User user = await _repo.findById(userId);
        //    //User u = await _repo.findByName(name);
        //    User u = await _repo.findByNameAndAssociation(name, (int)user.IdAssociation);

        //    PrivateUser u1 = new Library.Data.Models.PrivateUser();
        //    //u1.Function = u.IdUserFunctionNavigation.FunctionName;
        //    u1.Email = u.Email;
        //    u1.Surname = u.Surname;
        //    u1.Name = u.Name;
        //    u1.Cnp = u.Cnp;
        //    u1.License = u1.License;
        //    u1.Id = u.Id;
        //    ViewBag.PrivateUser = u1;
        //    ViewData["CurrentUser"] = user.Name + " " + user.Surname;
        //    return View();
        //}

        //[HttpPost("switchPageAsoc")]
        //public async Task<IActionResult> SwitchPage(String page_nb)
        //{
        //    int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        //    User user = await _repo.findById(userId);
        //    var users = await _repo.getUsersAsociation(user);
        //    var user_functions = await _repo.getAllUserFunctions();
        //    List<PrivateUser> privateUsers = new List<PrivateUser>();
        //    int userNb = _repo.getNumberOfUsersInAssociation((int)user.IdAssociation);
        //    int pageNb = 0;
        //    int usersOnPage = 5;
        //    double pages = (double)userNb / usersOnPage;
        //    int pagesNb = (int)Math.Ceiling(pages);

        //    List<int> pageList = new List<int>();
        //    switch (page_nb)
        //    {
        //        case "First":
        //            pageNb = 0;
        //            break;
        //        case "Last":
        //            pageNb = pagesNb - 1;
        //            break;
        //        default:
        //            pageNb = Int32.Parse(page_nb) - 1;
        //            break;
        //    }
        //    for (int i = pageNb * usersOnPage; i < pageNb * usersOnPage + usersOnPage && i < userNb; i++)
        //    {
        //        PrivateUser u1 = new Library.Data.Models.PrivateUser();
        //       // u1.Function = users[i].IdUserFunctionNavigation.FunctionName;
        //        u1.Email = users[i].Email;
        //        u1.Surname = users[i].Surname;
        //        u1.Name = users[i].Name;
        //        u1.Cnp = users[i].Cnp;
        //        u1.License = users[i].License;
        //        u1.Id = users[i].Id;
        //        privateUsers.Add(u1);
        //    }
        //    for (int i = 0; i < 3; i++)
        //    {
        //        pageList.Add(i);
        //    }
        //    int sendCurrent = pageNb + 1;
        //    ViewBag.LastPage = pagesNb;
        //    ViewBag.CurrentPage = sendCurrent;
        //    ViewBag.NumberOfPages = pageList;
        //    ViewData["PrivateUsers"] = privateUsers;
        //    ViewData["CurrentUser"] = user.Name + " " + user.Surname;
        //    return View();
        //}

        //public async Task<IActionResult> HuntingGrounds()
        //{
        //    int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        //    User user = await _repo.findById(userId);

        //    var huntgrounds = await _serv.getHuntingGroundsByAssociationId((int)user.IdAssociation);
        //    ViewData["HuntingGrounds"] = huntgrounds;
        //    return View();

        //}
    }
}

