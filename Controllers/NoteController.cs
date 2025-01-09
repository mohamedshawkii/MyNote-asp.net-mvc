using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Models.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class NoteController : Controller
    {
        private Repository<Note> Notes;
        public NoteController(ApplicationDbContext context)
        {
            Notes = new Repository<Note>(context);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CreatedNotesView = new CreatedNotesView();
            var model = await Notes.GetAllAsync();
            var userId = User.Identity.GetUserId();
            var filter = model.Where(x => x.ApplicationUserId == userId);
            CreatedNotesView.ListOfNotes = filter;

            return View(CreatedNotesView);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatedNotesView viewNote)
        {
            var userId = User.Identity.GetUserId();
            viewNote.NewNote.ApplicationUserId = userId;
            if(!TryValidateModel(viewNote.NewNote, nameof(CreatedNotesView.NewNote)))
            {
                await Notes.AddAsync(viewNote.NewNote);
                return RedirectToAction("Create");
            }
            return View();
        }
    }
}
