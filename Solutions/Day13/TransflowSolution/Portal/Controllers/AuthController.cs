using Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace Portal.Controllers;

using Repositories;
using Services;
using Entities;
public class AuthController : Controller
{
   public readonly IRegisterService _registerService;
   public readonly IUserService _userService;
   // Authentication related actions would go here
   public AuthController(IRegisterService registerService, IUserService userService)
   {
      _registerService = registerService;
      _userService = userService;
   }
   [HttpGet]
   public IActionResult Login()
   {
      return View();
   }
   [HttpPost]
   public async Task<IActionResult> Login(string username, string password)
   {
      // Authentication logic would go here
      var isValid = _userService.ValidateUser(username, password);
      if (isValid)
      {
         var claims = new List<Claim>
         {
            new Claim(ClaimTypes.Name, username)
         };

         var claimsIdentity = new ClaimsIdentity(claims,
                                                 CookieAuthenticationDefaults.AuthenticationScheme);
         var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

         // Sign in the user
         await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                       claimsPrincipal);
         this.Response.Redirect("/Products/Index");
         return View();
      }
      ViewBag.ErrorMessage = "Invalid username or password";
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
      User reg = new User()
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
   public IActionResult AccessDenied()
   {
      return View();
   }
   public IActionResult Logout()
   {
      // Logout logic would go here
      HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return RedirectToAction("Login", "Auth");
   }
}