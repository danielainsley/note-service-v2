using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteService.Models;

namespace NoteService.Services
{
    public class NoteClient : INoteClient
    {
        private NoteClientFactory _factory;

        public NoteClient()
        {
            _factory = new NoteClientFactory();
        }

        public async Task<IList<Note>> Get()
        {
            return await _factory.Get();
        }

        public async Task<Note> Get(int? id)
        {  
            return await _factory.Get(id);
        }

        public async Task<Boolean> Put(Note note)
        {
            return await _factory.Put(note);
        }

        public async Task<Boolean> Post(Note note)
        {
            return await _factory.Post(note);
        }

        public async Task<Boolean> Delete(int? id)
        {
            return await _factory.Delete(id);
        }
    }
}
