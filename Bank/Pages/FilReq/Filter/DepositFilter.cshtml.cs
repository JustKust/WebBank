using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bank.Pages.FilReq.Filter
{
    public class DepositFilterModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DepositFilterModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get; set; }
        public Currency Currency { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = _context.Currency.First(m => m.CurId == id);

            if (Currency == null)
            {
                return NotFound();
            }
            Deposit = await _context.Deposits
                .Include(e => e.Cur).Where(m => m.CurId == Currency.CurId).ToListAsync();
            return Page();
        }
    }
}
