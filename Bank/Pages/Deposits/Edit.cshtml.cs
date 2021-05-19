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

namespace Bank.Pages.Deposits
{
    public class EditModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public EditModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Deposit Deposit { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deposit = await _context.Deposits
                .Include(d => d.Cur).FirstOrDefaultAsync(m => m.DepId == id);

            if (Deposit == null)
            {
                return NotFound();
            }
           ViewData["CurId"] = new SelectList(_context.Currency, "CurId", "CurId");
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

            _context.Attach(Deposit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositExists(Deposit.DepId))
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

        private bool DepositExists(long id)
        {
            return _context.Deposits.Any(e => e.DepId == id);
        }
    }
}
