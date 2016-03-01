using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Notes.Core.Models;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class NewNoteViewModel : BaseViewModel
    {
        private IMvxCommand _createNewNoteCommand;

        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }

        public IMvxCommand CreateNewNoteCommand
            => _createNewNoteCommand ?? (_createNewNoteCommand = new MvxCommand(async ()=> await ExecuteCreateNewNoteCommand()));

        private async Task ExecuteCreateNewNoteCommand()
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
            var noteModel = new NoteModel
            {
                Title = NoteTitle,
                Note = NoteBody,
                CreateDateTime = DateTime.Now
            };
            LocalStorage.AddNote(noteModel);
        }
    }
}
