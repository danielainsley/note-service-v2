using System;

namespace NoteService.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
