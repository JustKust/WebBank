using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Currencies
{
    public class DeleteModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DeleteModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Currency Currency { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = await _context.Currency.FirstOrDefaultAsync(m => m.CurId == id);

            if (Currency == null)
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

            Currency = await _context.Currency.FindAsync(id);

            if (Currency != null)
            {
                _context.Currency.Remove(Currency);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
