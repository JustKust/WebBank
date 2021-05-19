using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Deposits
{
    public class DeleteModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DeleteModel(Bank.Data.bankDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deposit = await _context.Deposits.FindAsync(id);

            if (Deposit != null)
            {
                _context.Deposits.Remove(Deposit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
