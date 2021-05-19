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
    public class IndexModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public IndexModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Depositor> Depositor { get;set; }

        public async Task OnGetAsync()
        {
            Depositor = await _context.Depositors
                .Include(d => d.Dep)
                .Include(d => d.Em).ToListAsync();
        }
    }
}
