using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestIt.Data;
using RequestIt.Models;
using RequestIt.ViewModels;

namespace RequestIt.Controllers
{
    
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string option=null, string search=null)
        {
            var lst = from u in _context.Users
                join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                join r in _context.Roles
                    on ur.RoleId equals r.Id
                select new { u.UserName, u.Voornaam, u.Achternaam,u.Id, u.PhoneNumber, r.Name };

            List<UserRoleViewModel> lijstUserMetRoles  = new List<UserRoleViewModel>();
            foreach (var item in lst)
            {
                UserRoleViewModel u = new UserRoleViewModel
                {
                    UserName = item.UserName,
                    Voornaam = item.Voornaam,
                    Achternaam = item.Achternaam,
                    PhoneNumber = item.PhoneNumber,
                    UserId = item.Id,
                    RoleName = item.Name
                };
            }

            var result = await lst.ToListAsync();

            return View(result);
        }

        [Authorize(Roles = "Admin,Behandelaar")]
        public async Task<IActionResult> IndexGebruikerAanvragen()
        {
            var UsersAanvragen = _context.Users.Include(u => u.Aanvragen);

            List<GebruikersAanvragenStatusViewModel> lijstGebrAanStat = new List<GebruikersAanvragenStatusViewModel>();

            foreach (var item in UsersAanvragen)
            {
                GebruikersAanvragenStatusViewModel u = new GebruikersAanvragenStatusViewModel
                {
                    UserId = item.Id,
                    Voornaam = item.Voornaam,
                    Achternaam = item.Achternaam,
                    Gebruikersnaam = item.UserName,
                   
                    Aanvragen = item.Aanvragen
                };
                lijstGebrAanStat.Add(u);
            }
            
            return View(lijstGebrAanStat);
        }


        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
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

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
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
