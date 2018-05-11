using Newtonsoft.Json;
using NoteService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Services
{
    public class NoteClientFactory
    {
        private static String url = "http://localhost:52255/api/notes";

        private HttpClient _client;

        public NoteClientFactory()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IList<Note>> Get()
        {
            var str = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IList<Note>>(str);
        }

        public async Task<Note> Get(int? id)
        {
            var str = await _client.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Note>(str);
        }

        public async Task<Boolean> Put(Note note)
        {       
            var result = await _client.PutAsync(url + "/" + note.ID, Content(note));
            return result.IsSuccessStatusCode;
        }

        public async Task<Boolean> Post(Note note)
        {
            var result = await _client.PostAsync(url, Content(note));
            return result.IsSuccessStatusCode;
        }

        public async Task<Boolean> Delete(int? id)
        {
            var result = await _client.DeleteAsync(url + "/" + id);
            return result.IsSuccessStatusCode;
        }

        private StringContent Content(Note note)
        {
            return new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
        }

        ~NoteClientFactory()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }
    }
}
