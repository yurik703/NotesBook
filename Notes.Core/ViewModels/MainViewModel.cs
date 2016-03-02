using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Notes.Core.EventsMessages;
using Notes.Core.Models;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : BaseViewModel
    {
        private readonly MvxSubscriptionToken _newNoteAddedMessageToken;
        private readonly MvxSubscriptionToken _updateNoteMessageToken;

        private IMvxCommand _newNoteCommand;
        private IMvxCommand _editNoteCommand;
        private IMvxCommand _removeNoteCommand;
        private IMvxCommand _itemSelectedCommand;

        public ObservableCollection<NoteModel> Notes { get; set; } 

        [DoNotNotify]
        public IMvxCommand NewNoteCommand => _newNoteCommand ?? (_newNoteCommand = new MvxCommand(ExecuteNewNoteCommand));
        [DoNotNotify]
        public IMvxCommand EditNoteCommand => _editNoteCommand ?? (_editNoteCommand = new MvxCommand<Int32>(ExecuteEditNoteCommand));
        [DoNotNotify]
        public IMvxCommand RemoveNoteCommand => _removeNoteCommand ?? (_removeNoteCommand = new MvxCommand<Int32>(async (id) => await ExecuteRemoveNoteCommand(id)));
        [DoNotNotify]
        public IMvxCommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new MvxCommand<NoteModel>(ExecuteItemClickCommand));


        public MainViewModel()
        {
            _newNoteAddedMessageToken = Messenger.Subscribe<NewNoteAddedMessage>(AddNewNote);
            _updateNoteMessageToken = Messenger.Subscribe<UpdateNoteMessage>(UpdateNote);
            InitModel();
        }

        private void InitModel()
        {
            var notes = LocalStorage.GetNotes();
            Notes = new ObservableCollection<NoteModel>(notes);
        }

        private void UpdateNote(UpdateNoteMessage e)
        {
            InitModel();
        }

        private void AddNewNote(NewNoteAddedMessage newNoteAddedMessage)
        {
            InitModel();
        }

        private void ExecuteItemClickCommand(NoteModel note)
        {
            ShowViewModel<NoteViewModel>(note);
        }

        private void ExecuteNewNoteCommand()
        {
            ShowViewModel<NewNoteViewModel>();
        }

        private void ExecuteEditNoteCommand(int positionId)
        {
            var note = Notes[positionId];
            ShowViewModel<EditNoteViewModel>(note);
        }

        private async Task ExecuteRemoveNoteCommand(int positionId)
        {
            var result = await AlertsService.ShowAlert("Confirm", "Are you sure want to delete a note?", "Ok", "Cancel");
            if (result)
            {
                var note = Notes[positionId];
                Notes.Remove(note);
                LocalStorage.RemoveNote(note.Id);
            }
        }
    }
}
