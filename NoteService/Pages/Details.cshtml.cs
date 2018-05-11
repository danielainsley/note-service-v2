using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteService.Models;
using NoteService.Services;

namespace NoteService.Pages.Notes
{
    public class DetailsModel : PageModel
    {
        private readonly INoteClient _noteClient;

        public DetailsModel(INoteClient noteClient)
        {
            _noteClient = noteClient;
        }

        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _noteClient.Get(id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
