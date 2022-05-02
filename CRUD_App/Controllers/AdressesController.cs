using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_App.Data;
using CRUD_App.Models;

namespace CRUD_App.Controllers
{
    public class AdressesController : Controller
    {
        private readonly AppDbContext _context;

        public AdressesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Adresses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Adress.Include(a => a.Country).Include(a => a.Customer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Adresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .Include(a => a.Country)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.AdressID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // GET: Adresses/Create
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "CountryID", "Name");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName");
            ViewData["AdressType"] = new SelectList(Enum.GetValues(typeof(Adress.AdressType)));
            return View();
        }

        // POST: Adresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerID,StreetAdress,City,Zip,CountryID,Type")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "CountryID", "Name", adress.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "FullName", adress.CustomerID);
            return View(adress);
        }

        // GET: Adresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress.SingleAsync(a => a.AdressID == id);
            if (adress == null)
            {
                return NotFound();
            }

            

            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "CountryID", "Name", adress.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "FullName", adress.CountryID);
            ViewData["AdressType"] = new SelectList(Enum.GetValues(typeof(Adress.AdressType)), adress.Type);

            return View(adress);
        }

        // POST: Adresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdressID,CustomerID,StreetAdress,City,Zip,CountryID,Type")] Adress adress)
        {
            if (id != adress.AdressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressExists(adress.AdressID))
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

            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "ID", adress.CountryID);
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID", adress.CustomerID);
            return View(adress);
        }


        // GET: Adresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .Include(a => a.Country)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.AdressID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adress = await _context.Adress.FindAsync(id);
            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdressExists(int id)
        {
            return _context.Adress.Any(e => e.AdressID == id);
        }
    }
}
