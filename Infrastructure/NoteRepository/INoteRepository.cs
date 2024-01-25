
using WebApplication3.Domain;

namespace Infrastructure.NoteRepository
{
    public interface INoteRepository
    {
        Task AddNoteInRepositoryAsync(Note note);
       
    }
}