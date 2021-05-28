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
    public class DepositorsModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DepositorsModel(Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get; set; }
        public IList<Depositor> Depositor { get; set; }
        public IList<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposits.ToListAsync();
            Depositor = await _context.Depositors.ToListAsync();
            Employees = await _context.Employee.ToListAsync();
        }
    }
}
