using Algebra_Seminar_Drdic.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Algebra_Seminar_Drdic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                 ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        
        public IActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }
    }
}
