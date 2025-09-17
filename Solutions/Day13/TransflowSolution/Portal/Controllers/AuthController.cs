using Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers;

using Repositories;
using Services;
using Entities;
public class AuthController : Controller
{
   public readonly IRegisterService _registerService;
   // Authentication related actions would go here
   public AuthController(IRegisterService registerService)
   {
      _registerService = registerService;
   }
   [HttpGet]
   public IActionResult Login()
   {
      return View();
   }
   [HttpPost]
   public IActionResult Login(string email, string password)
   {
      // Authentication logic would go here
      // For now, just redirect to products page
      this.Response.Redirect("/Products/Index");
      return View();
   }
   [HttpGet]
   public IActionResult Register()
   {
      return View();
   }
   [HttpPost]
   public IActionResult Register(string firstname, string lastname, string email, string password)
   {
      // Registration logic would go here
      // For now, just redirect to products page
      UserRegistration reg = new UserRegistration()
      {
         FirstName = firstname,
         LastName = lastname,
         Email = email,
         Password = password
      };
      _registerService.RegisterUser(reg);
      this.Response.Redirect("/Products/Index");
      return View();
   }
}