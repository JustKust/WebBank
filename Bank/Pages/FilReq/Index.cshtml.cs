using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bank.Pages.FilReq.Request
{
    public class IndexModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public IndexModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Employee { get; set; }
        public List<SelectListItem> Depositor { get; set; }
        public List<SelectListItem> Deposit { get; set; }
        public List<SelectListItem> Currency { get; set; }
        public IActionResult OnGet()
        {
            Position = _context.Positions.Select(p =>
               new SelectListItem
               {
                   Value = p.PosId.ToString(),
                   Text = p.PosName
               }).ToList();

            Employee = _context.Employee.Select(p =>
               new SelectListItem
               {
                   Value = p.EmId.ToString(),
                   Text = p.FullName
               }).ToList();

            Depositor = _context.Depositors.Select(p =>
               new SelectListItem
               {
                   Value = p.DepId.ToString(),
                   Text = p.FullName
               }).ToList();

            Deposit = _context.Deposit.Select(p =>
               new SelectListItem
               {
                   Value = p.DepId.ToString(),
                   Text = p.DepName
               }).ToList();

            Currency = _context.Currency.Select(p =>
               new SelectListItem
               {
                   Value = p.CurId.ToString(),
                   Text = p.Name
               }).ToList();

            return Page();
        }
    }
}
