using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMA.Models;
using RMA.Repository;
using RMA.ViewModels;

namespace RMA.Controllers
{
    public class AccountController : Controller
    {
       
        public readonly SignInManager<IdentityUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<IdentityUser> _userManager;

        public readonly IAdminRepository _adminRepository;


        public AccountController(IAdminRepository adminRepository, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _adminRepository = adminRepository;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            LoginViewModel model = new();

            if(ReturnUrl!="/" && !string.IsNullOrEmpty(ReturnUrl))
            {
                model.ReturnUrl = ReturnUrl;
            }

            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel loginModel)
        {
            var user=await _userManager.FindByEmailAsync(loginModel.Email);
            if(user!=null)
            {
                var login =await _signInManager.PasswordSignInAsync(user,loginModel.Password,loginModel.RememberMe,false);
                if(login.Succeeded)
                {
                    TempData["Login"] = true;
                    if(loginModel.ReturnUrl==null)
                    //TempData.Keep("Login");
                    return Redirect(loginModel.ReturnUrl);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            TempData["Login"] = false;
            return RedirectToAction("Index","Home");
            
        }
        //public IActionResult Login(LoginViewModel loginmodel)
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel usermodel)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = usermodel.Name,
                Email = usermodel.Email
            };
            var res = await _userManager.CreateAsync(user, usermodel.Password);
            if(res.Succeeded)
            {
               await _signInManager.SignInAsync(user,isPersistent:true);
                TempData["Login"] = true;
               return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(List<Role> roles)
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
