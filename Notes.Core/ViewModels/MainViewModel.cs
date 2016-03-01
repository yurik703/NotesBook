using System;
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
        private IMvxCommand _editNoteCommand;
        private IMvxCommand _removeNoteCommand;

        public ObservableCollection<NoteModel> Notes { get; set; } 

        public IMvxCommand NewNoteCommand => _newNoteCommand ?? (_newNoteCommand = new MvxCommand(ExecuteNewNoteCommand));
        public IMvxCommand EditNoteCommand => _editNoteCommand ?? (_editNoteCommand = new MvxCommand<Int32>(ExecuteEditNoteCommand));
        public IMvxCommand RemoveNoteCommand => _removeNoteCommand ?? (_removeNoteCommand = new MvxCommand<Int32>(ExecuteRemoveNoteCommand));


        public MainViewModel()
        {
            InitModel();
        }

        private void InitModel()
        {
            var notes = LocalStorage.GetNotes();
            Notes = new ObservableCollection<NoteModel>(notes);
        }

        private void ExecuteNewNoteCommand()
        {
            ShowViewModel<NewNoteViewModel>();
        }

        private void ExecuteEditNoteCommand(int positionId)
        {
            //TODO: Inplement edit note
        }

        private void ExecuteRemoveNoteCommand(int positionId)
        {
            //TODO: Implement remove note
        }
    }
}
