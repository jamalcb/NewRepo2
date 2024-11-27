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
        public IActionResult Login()
        {
            return View();
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
            return View();
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
