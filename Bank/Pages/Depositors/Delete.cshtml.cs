using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Depositors
{
    public class DeleteModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DeleteModel(Bank.Data.bankDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Depositor = await _context.Depositors.FindAsync(id);

            if (Depositor != null)
            {
                _context.Depositors.Remove(Depositor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
