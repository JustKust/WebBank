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
    public class PersonnelDepartmentModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public PersonnelDepartmentModel(Data.bankDBContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public IList<Position> Position { get; set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee
                .Include(e => e.Pos).ToListAsync();
            Position = await _context.Positions.ToListAsync();
        }
    }
}
