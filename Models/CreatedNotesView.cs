
namespace HelloWorld.Models
{
    public class CreatedNotesView
    {
        public Note NewNote { get; set; }
        public IEnumerable<Note> ListOfNotes { get; set; }
    }
}
