using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using HuntingAssociation.Models;

namespace HuntingAssociationUI.Controllers
{
    public class SysAdminController:Controller
    {
        public IActionResult Index(){
            List<UserFunction> functions=new List<UserFunction>();
            List<Association> associatinos=new List<Association>();


            UserFunction f1=new UserFunction();
            f1.FunctionName="Director";
            f1.Id=1;

            UserFunction f2=new UserFunction();
            f2.FunctionName="Sef";
            f2.Id=2;

            functions.Add(f1);
            functions.Add(f2);

            Association a1=new Association();
            a1.Name="Rad SRL";
            associatinos.Add(a1);

            Association a2=new Association();
            a2.Name="Voicu Sabie SA";
            associatinos.Add(a2);

            ViewBag.UserName="Admin Bo$$";
            ViewBag.Role="SysAdmin";
            ViewData["Functions"]=functions;
            ViewData["Associations"]=associatinos;
            return View();
        }
    }
}