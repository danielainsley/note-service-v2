using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteService.Models;
using NoteService.Services;

namespace NoteService.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly INoteClient _noteClient;

        public CreateModel(INoteClient noteClient)
        {
            _noteClient = noteClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _noteClient.Post(this.Note);

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