using System;
using Notes.Core.Models;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class NoteViewModel : BaseViewModel
    {
        private NoteModel note;

        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }
        public DateTime NoteCreateDataTime { get; set; }

        public void Init(NoteModel note)
        {
            this.note = note;
            NoteTitle = note.Title;
            NoteBody = note.Note;
            NoteCreateDataTime = note.CreateDateTime;
        }
    }
}
