using Microsoft.AspNetCore.Mvc;
using NoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Services
{
    public interface INoteClient
    {
        Task<IList<Note>> Get();
        Task<Note> Get(int? id);
        Task<Boolean> Put(Note note);
        Task<Boolean> Post(Note note);
        Task<Boolean> Delete(int? id);
    }
}
