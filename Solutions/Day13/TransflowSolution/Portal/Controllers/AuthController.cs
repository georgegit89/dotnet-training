using Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers;

public class AuthController : Controller
{
   // Authentication related actions would go here
   public AuthController()
   {

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

   public IActionResult Register()
   {
      return View();
   }
}