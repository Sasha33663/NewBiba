using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Domain;

namespace Infrastructure.NoteRepository
{
    public class NoteRepository : INoteRepository
    {
        private readonly Database _database;

        public NoteRepository(Database database)
        {
            _database = database;
        }

        public async Task AddNoteInRepositoryAsync(Note note)
        {
            await _database.Notes.AddAsync(note);
            await _database.SaveChangesAsync();
        }
    }

}
