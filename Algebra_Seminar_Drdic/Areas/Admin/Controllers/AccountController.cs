using Algebra_Seminar_Drdic.Data;
using Algebra_Seminar_Drdic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Algebra_Seminar_Drdic.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public ActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(string id) //??
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            
            var roleId = _context.UserRoles.FirstOrDefault(ur => ur.UserId == id).RoleId;
            var roleName = _context.Roles.FirstOrDefault(u => u.Id == roleId).Name;
            ViewBag.UserRole = roleName;

            return View(user);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            var roles = _context.Roles.ToList();
            ViewBag.Roles = roles;

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUser user, string roleName, string password, string confirmPassword)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessageC"] = "Ispunite sva polja!";
                return RedirectToAction("Create");
                
            }
            if (password != confirmPassword)
            {
                TempData["AllertMessageD"] = "Lozinka nije potvrđena. Ponovite unos!";
                return RedirectToAction("Create");
            }

            try
            {
                if (password == confirmPassword)
                {
                    var hasher = new PasswordHasher<ApplicationUser>();

                    var passwordHash = hasher.HashPassword(null, password);

                    user.PasswordHash = passwordHash;
                }

                user.UserName = user.Email;
                user.NormalizedUserName = user.Email.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();


                _context.Users.Add(user);

                var roleid = _context.Roles.FirstOrDefault(ri => ri.Name == roleName).Id;

                IdentityUserRole<string> userole = new IdentityUserRole<string>();
                userole.UserId = user.Id;
                userole.RoleId = roleid;

                
                _context.UserRoles.Add(userole);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(string id)
        {
            var roles = _context.Roles.ToList();
            ViewBag.Roles = roles;

            var roleId = _context.UserRoles.FirstOrDefault(ur => ur.UserId == id).RoleId;
            var roleName = _context.Roles.FirstOrDefault(u => u.Id == roleId).Name;
            ViewBag.UserRole = roleName;

            var user = _context.Users.FirstOrDefault(u =>u.Id == id);

            return View(user);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user, string roleName, string password, string confirmPassword)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessageE"] = "Ispunite sva polja!";
                return RedirectToAction("Edit");

            }
            if (password != confirmPassword)
            {
                TempData["AllertMessageF"] = "Lozinka nije potvrđena. Ponovite unos!";
                return RedirectToAction("Edit");
            }

            try
            {

                if(password == confirmPassword)
                {
                    var hasher = new PasswordHasher<ApplicationUser>();

                    var passwordHash = hasher.HashPassword(null, password);

                    user.PasswordHash = passwordHash;
                }
                var oldUser = _context.Users.FirstOrDefault(ou => ou.Id == user.Id);
                oldUser.UserName = user.Email;
                oldUser.NormalizedUserName = user.Email.ToUpper();
                oldUser.Email = user.Email;
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;

                var userRole = _context.UserRoles.SingleOrDefault(ur => ur.UserId == oldUser.Id);
                _context.UserRoles.Remove(userRole);

                _context.SaveChanges();

                var roleid = _context.Roles.FirstOrDefault(ri => ri.Name == roleName).Id;

                IdentityUserRole<string> userole = new IdentityUserRole<string>();
                userole.UserId = user.Id;
                userole.RoleId = roleid;


                _context.UserRoles.Add(userole);

                _context.Users.Update(oldUser);
                
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(DBConcurrencyException dbcx)
            {
                return RedirectToAction("Edit", new { error_message = dbcx.Message });
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(string id)
        {
            var roleId = _context.UserRoles.FirstOrDefault(ri => ri.UserId == id).RoleId;
            var userRole = _context.Roles.FirstOrDefault(ur => ur.Id == roleId).Name;
            ViewBag.UserRole = userRole;

            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, string roleName)
        {
            try
            {
             
                var userRole = _context.UserRoles.SingleOrDefault(ur => ur.UserId == id);
                var role = _context.Roles.FirstOrDefault(u => u.Id == userRole.RoleId).Name;
                var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
                
                if(roleName == role)
                    _context.UserRoles.Remove(userRole);
                
                

                _context.Users.Remove(user);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}