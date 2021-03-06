using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Depositors
{
    public class CreateModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public CreateModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepId"] = new SelectList(_context.Deposits, "DepId", "");
        ViewData["EmId"] = new SelectList(_context.Employee, "EmId", "");
            return Page();
        }

        [BindProperty]
        public Depositor Depositor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Depositors.Add(Depositor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
