using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Authorize]
    public class ProfileController:Controller
    {
        private readonly IUserService _repo;

         public ProfileController(IUserService repo){
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string error_pass){
            int userId=Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

             User user= await _repo.findById(userId);

            PrivateUser u1 =new PrivateUser();

            u1.Id=user.Id;
            u1.Email=user.Email;
            
            u1.Surname=user.Surname;
            u1.Name=user.Name;
            u1.Cnp=user.Cnp;
            u1.License=user.License;
            u1.Insurance=user.Insurance;
            ViewBag.CurrentUser=u1;
            ViewBag.UserName=u1.Name+" "+u1.Surname;
            if(!string.IsNullOrEmpty(error_pass)){
                ViewBag.Error="Password Incorect!!";
            }
            return View();
        }

        [HttpPost("/profile/change_user_data")]
        public async Task<IActionResult> Change_user_data(string user_email, string user_name,
        string user_surname, string user_insurance,
        string user_old_pass, string user_new_pass,string user_new_pass_confirm){
                
                int userId=Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                User user= await _repo.findById(userId);
                
                if(user_old_pass=="" && !user_new_pass.Equals("")){
                    if(user.Password.Equals(user_old_pass)){
                            _repo.updateUserOperator(user,user_email,user_new_pass,user_name,user_surname,user_insurance);
                    }else{
                            return RedirectToAction("Index","Profile",new{error_pass="Yes"});
                    }
                }else{
                    _repo.updateUserOperator(user,user_email,user.Password,user_name,user_surname,user_insurance);
                }

                
                
                
                return RedirectToAction("Index","Home");

        }

       
    

    }
}