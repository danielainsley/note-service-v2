using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteService.Models;
using NoteService.Services;

namespace NoteService.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly INoteClient _noteClient;

        public EditModel(INoteClient noteClient)
        {
            _noteClient = noteClient;
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _noteClient.Get(id.Value);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _noteClient.Put(this.Note);

            if (result)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
