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
    public class DetailsModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DetailsModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

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
    }
}
