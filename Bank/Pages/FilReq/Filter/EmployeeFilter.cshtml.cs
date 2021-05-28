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
    public class EmployeeFilterModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public EmployeeFilterModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Positions.First(m => m.PosId == id);

            if (Position == null)
            {
                return NotFound();
            }
            Employee = await _context.Employee
                .Include(e => e.Pos).Where(m => m.PosId == Position.PosId).ToListAsync();
            return Page();
        }
    }
}
