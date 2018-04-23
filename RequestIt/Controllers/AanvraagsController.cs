using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Authorize]
    public class AanvraagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AanvraagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aanvraags
        public async Task<IActionResult> Index(string userId = null)
        {
            if (userId == null)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var model = new AanvraagAndCustomerViewModel
            {
                Aanvragen = _context.Aanvragen.Where(a => a.UserId == userId),
                UserObj = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId)
            };

            return View(model);
        }

        // GET: Aanvraags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanvraag = await _context.Aanvragen
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aanvraag == null)
            {
                return NotFound();
            }

            return View(aanvraag);
        }

        // GET: Aanvraags/Create
        public IActionResult Create(string userId)
        {
            Aanvraag aanvraag = new Aanvraag
            {
                UserId = userId
            };
            return View(aanvraag);
        }

        // POST: Aanvraags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aanvraag aanvraag)
        {          
            if (ModelState.IsValid)
            {
                _context.Add(aanvraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { userId = aanvraag.UserId });
            }
            return View(aanvraag);
        }

        // GET: Aanvraags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanvraag = await _context.Aanvragen.SingleOrDefaultAsync(m => m.Id == id);
            if (aanvraag == null)
            {
                return NotFound();
            }
            return View(aanvraag);
        }

        // POST: Aanvraags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titel,Omschrijving,StartDatum,EindDatum,LinkVoorbeeldKlant,LinkVoorbeeldBehandelaar")] Aanvraag aanvraag)
        {
            if (id != aanvraag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aanvraag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AanvraagExists(aanvraag.Id))
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
            return View(aanvraag);
        }

        // GET: Aanvraags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanvraag = await _context.Aanvragen
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aanvraag == null)
            {
                return NotFound();
            }

            return View(aanvraag);
        }

        // POST: Aanvraags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aanvraag = await _context.Aanvragen.SingleOrDefaultAsync(m => m.Id == id);
            _context.Aanvragen.Remove(aanvraag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AanvraagExists(int id)
        {
            return _context.Aanvragen.Any(e => e.Id == id);
        }
    }
}
