using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/notes")]
    public partial class NoteController : Controller
    {
        private readonly IUserServes _userServes;

        public NoteController(IUserServes userServes)
        {
            _userServes = userServes;
        }

        [HttpPost("create")]

        public async Task<IActionResult> Create([FromBody] NoteDTO noteDTO)
        {
            var b = await _userServes.NoteCreatAsync(noteDTO.Header, noteDTO.Text, noteDTO.UserID);

            var response = new CreateResponseDTO
            {
                NoteId = b.ID,
                Header = b.Header,
                Text = b.Text,
                Date = b.Date,
                UserId = b.UserID,
                UserName = b.User.Name
            };

            return Json(response);
        }

    }
}

public class CreateResponseDTO
{
    public Guid NoteId { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public DateTime Date { get; set; }

}
