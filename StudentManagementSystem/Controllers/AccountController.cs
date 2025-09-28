using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Save user to database (not implemented here)
                // Create Cookie

                //UserManager<ApplicationUser> userManager=new UserManager<ApplicationUser>();

                ApplicationUser newUser = new ApplicationUser();
                
                    newUser.UserName = user.UserName;
                    newUser.Email = user.Email;
                    newUser.PasswordHash = user.Password; // Note: In a real application, ensure to hash the password properly.
                    newUser.Address = user.Address;

                IdentityResult result= await userManager.CreateAsync(newUser,user.Password);
                
                
                if (result.Succeeded)
                {
                    // Create Cookie like a Student Unique ID Card

                   await signInManager.SignInAsync(newUser, false);

                    return RedirectToAction("GetAll", "Student");



                }
                
 
                    foreach(var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            return View("Register", user);
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser appUser= await userManager.FindByNameAsync(user.Username);
                if(appUser != null)
                {
                  bool found =  await userManager.CheckPasswordAsync(appUser,user.Password);
                    if(found)
                    {
                        //await  signInManager.SignInAsync(appUser, user.RememberMe);

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address",appUser.Address));


                        await signInManager.SignInWithClaimsAsync(appUser, user.RememberMe, claims);

                        return RedirectToAction("GetAll", "Student");
                    }
                    

                }

            }

            ModelState.AddModelError("", "Username OR Passward Wrong");

            return View(user);

        }

        public async Task<IActionResult> SignOut()
        {
          await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult TestAuthorized()
        {
            if (User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var Claim1 = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                var id = Claim1.Value;
                var Claim2 = User.Claims.FirstOrDefault(c => c.Type == "Address");
                var address = Claim2.Value;

                return Content($"Hello {name} \n Your id = {id} \n Your Address is {address} ");
            }
            return Content("Not Authonticated");
        }
    }
}
