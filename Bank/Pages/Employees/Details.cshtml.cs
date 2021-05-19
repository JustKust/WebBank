using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DetailsModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee
                .Include(e => e.Pos).FirstOrDefaultAsync(m => m.EmId == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
