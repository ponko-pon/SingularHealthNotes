using Microsoft.AspNetCore.Mvc;
using SingularHealthNotesAPI.Models;
using SingularHealthNotesAPI.Services;

namespace SingularHealthNotesAPI.Controllers
{
    [ApiController]
    [Route("scans")]
    public class ScansController(IScanService scanService) : ControllerBase
    {
        private readonly IScanService _scanService = scanService;

        [HttpGet]
        public ActionResult<List<Scan>> GetAllScans()
        {
            var scans = _scanService.GetAll();
            return Ok(scans);
        }

        [HttpGet("{id:guid}/notes")]
        public ActionResult<Note[]> GetNotes(Guid id)
        {
            var notes = _scanService.GetNotesByScanId(id);
            if (notes.Length == 0)
                return NotFound(new { Message = $"No notes found for Scan ID {id}" });

            return Ok(notes);
        }

        [HttpPost("{id:guid}/notes")]
        public ActionResult AddNote(Guid id, [FromBody] Scan scan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingScan = _scanService.GetAll().Find(s => s.Id == id);

            if (existingScan == null)
                return NotFound(new { Message = $"Scan with ID {id} not found" });

            _scanService.Save(scan);

            return NoContent();
        }
    }
}
