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
    public class IndexModel : PageModel
    {
        private readonly INoteClient _noteClient;

        public IndexModel(INoteClient noteClient)
        {
            _noteClient = noteClient;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            var _note = await _noteClient.Get();
            this.Note = _note;
        }
    }
}
