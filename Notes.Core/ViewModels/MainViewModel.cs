using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using Notes.Core.Models;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : BaseViewModel
    {
        private IMvxCommand _newNoteCommand;

        public ObservableCollection<NoteModel> Notes { get; set; } 

        public IMvxCommand NewNoteCommand => _newNoteCommand ?? (_newNoteCommand = new MvxCommand(ExecuteNewNoteCommand));

        private void ExecuteNewNoteCommand()
        {
            ShowViewModel<NewNoteViewModel>();
        }

        public MainViewModel()
        {
            InitModel();
        }

        private void InitModel()
        {
            var notes = LocalStorage.GetNotes();
            var newnotes = new List<NoteModel>(notes);

            for (int i = 0; i < 1000; i++)
            {
                newnotes.AddRange(notes);
            }
            
            Notes = new ObservableCollection<NoteModel>(newnotes);
        }
    }
}
