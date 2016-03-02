using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Notes.Core.EventsMessages;
using Notes.Core.Models;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class EditNoteViewModel : BaseViewModel
    {
        private IMvxCommand _editNoteCommand;
        private NoteModel note;

        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }

        [DoNotNotify]
        public IMvxCommand EditNoteCommand => _editNoteCommand ?? (_editNoteCommand = new MvxCommand(async () => await ExecuteEditNoteCommand()));

        public void Init(NoteModel note)
        {
            this.note = note;
            NoteTitle = note.Title;
            NoteBody = note.Note;
        }

        private async Task ExecuteEditNoteCommand()
        {
            if (String.IsNullOrWhiteSpace(NoteTitle))
            {
                await AlertsService.ShowAlert("Error", "Title can not be empty");
                return;
            }
            if (String.IsNullOrWhiteSpace(NoteBody))
            {
                await AlertsService.ShowAlert("Error", "Note can not be empty");
                return;
            }
            note.Title = NoteTitle;
            note.Note = NoteBody;
            LocalStorage.UpdateNote(note);
            Messenger.Publish(new UpdateNoteMessage(this, note));
            Close(this);
        }
    }
}
