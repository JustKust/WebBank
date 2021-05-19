﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Positions
{
    public class DetailsModel : PageModel
    {
        private readonly Bank.Data.bankDBContext _context;

        public DetailsModel(Bank.Data.bankDBContext context)
        {
            _context = context;
        }

        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FirstOrDefaultAsync(m => m.PosId == id);

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
