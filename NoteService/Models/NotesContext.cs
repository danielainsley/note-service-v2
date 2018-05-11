using Microsoft.EntityFrameworkCore;

namespace NoteService.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options)
           : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
