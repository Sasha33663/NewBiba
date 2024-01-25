using Domain;

namespace Application;

public class DeleteResultDTO
{
    public User DeletedUser { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
