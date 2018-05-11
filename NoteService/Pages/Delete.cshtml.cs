using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteService.Models;
using NoteService.Services;

namespace NoteService.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly INoteClient _noteClient;

        public DeleteModel(INoteClient noteClient)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _noteClient.Delete(id);

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
