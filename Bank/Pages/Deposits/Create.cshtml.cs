using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Deposits
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
        ViewData["CurId"] = new SelectList(_context.Currency, "CurId", "CurId");
            return Page();
        }

        [BindProperty]
        public Deposit Deposit { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Deposits.Add(Deposit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
