using MvvmCross.Core.ViewModels;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class NewNoteViewModel : MvxViewModel
    {
        private IMvxCommand _createNewNoteCommand;

        public string Title { get; set; }
        public string Content { get; set; }

        public IMvxCommand CreateNewNoteCommand
            => _createNewNoteCommand ?? (_createNewNoteCommand = new MvxCommand(ExecuteCreateNewNoteCommand));

        private void ExecuteCreateNewNoteCommand()
        {
            //TODO: Impement save new note to local db
        }
    }
}
