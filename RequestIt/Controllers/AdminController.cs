using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestIt.Data;
using RequestIt.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }    
                
        public async Task<IActionResult> Index()
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
                    UserName = item.UserName,
                    AanvragenCount = item.Aanvragen.Count              
                };
                lijst.Add(u);
            }
            return View(lijst);
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