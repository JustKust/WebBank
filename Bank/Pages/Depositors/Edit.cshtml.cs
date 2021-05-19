using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Depositors
{
    public class EditModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public EditModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Depositor Depositor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Depositor = await _context.Depositors
                .Include(d => d.Dep)
                .Include(d => d.Em).FirstOrDefaultAsync(m => m.PassData == id);

            if (Depositor == null)
            {
                return NotFound();
            }
           ViewData["DepId"] = new SelectList(_context.Deposits, "DepId", "AddCond");
           ViewData["EmId"] = new SelectList(_context.Employee, "EmId", "Adress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Depositor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositorExists(Depositor.PassData))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepositorExists(string id)
        {
            return _context.Depositors.Any(e => e.PassData == id);
        }
    }
}
