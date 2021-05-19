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
    public class IndexModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public IndexModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get;set; }

        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposits
                .Include(d => d.Cur).ToListAsync();
        }
    }
}
