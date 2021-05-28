using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bank.Pages.FilReq.Request
{
    public class DepositsModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DepositsModel(Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get; set; }
        public IList<Currency> Currency { get; set; }

        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposits.ToListAsync();
            Currency = await _context.Currency.ToListAsync();
        }
    }
}
