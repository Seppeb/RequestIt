using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestIt.Data;
using RequestIt.Models;
using RequestIt.ViewModels;

namespace RequestIt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ApplicationUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string option=null, string search=null)
        {
            //data ophalen joins
            var lst = from u in _context.Users
                      join ur in _context.UserRoles
                          on u.Id equals ur.UserId
                      join r in _context.Roles
                          on ur.RoleId equals r.Id
                      select new { u.UserName, u.Voornaam, u.Achternaam, u.Id, r.Name };

            //viewmodel initialisersn
            List<ApplicationUserIndexViewModel> lijstUserMetRoles = new List<ApplicationUserIndexViewModel>();

            //opvullen van viewmodel met data
            foreach (var item in lst)
            {
                ApplicationUserIndexViewModel u = new ApplicationUserIndexViewModel
                {
                    Username = item.UserName,
                    UserId = item.Id,
                    Voornaam = item.Voornaam,
                    Achternaam = item.Achternaam,                 
                    Rol = item.Name
                };
                lijstUserMetRoles.Add(u);
            }

            return View(lijstUserMetRoles);
        }

        [Authorize(Roles = "Admin,Behandelaar")]
        public async Task<IActionResult> IndexGebruikerAanvragen()
        {
            var lijst = new List<UsersAanvraagStatusViewModel>();

            var UsersAanvragenStatus = _context.Users
                .Include(use => use.Aanvragen)
                    .ThenInclude(aanvraag => aanvraag.Status)                
                .ToList();

            foreach (var item in UsersAanvragenStatus)
            {
                UsersAanvraagStatusViewModel u = new UsersAanvraagStatusViewModel
                {
                  Aanvragen = item.Aanvragen,
                  UserId = item.Id,
                  Voornaam = item.Voornaam,
                  Achternaam = item.Achternaam,
                  UserName = item.UserName          
                  
                };
                lijst.Add(u);
            }          
            return View(lijst);
        }

        //[Authorize(Roles = "Admin,Behandelaar")]
        //public IActionResult IndexManagement()
        //{

        //    var userWithRoles =
        //        (from user in _context.Users
        //         from userRole in user.Roles
        //         join role in _context.Roles
        //         on userRole.RoleId equals role.Id
        //         select new ApplicationUserIndexManagementViewModel()
        //         {

        //         }).ToList();

        //    return View(userWithRoles);
        //}

        //// GET: ApplicationUsers/Details/5
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
            
        //    var applicationUser = await _context.ApplicationUser
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (applicationUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicationUser);
        //}


        [Authorize(Roles = "Admin")]
        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Voornaam,Achternaam,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

      
        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            
            ApplicationUserEditViewModel create = new ApplicationUserEditViewModel
            {
                Userbyid = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id)
                 
            };
            
            
            
            return View(create);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Voornaam,Achternaam,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
