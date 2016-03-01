using MvvmCross.Core.ViewModels;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : MvxViewModel
    {
        public string Hello { get; set; } = "Hello MvvmCross";

        private IMvxCommand _newNoteCommand;

        public IMvxCommand NewNoteCommand => _newNoteCommand ?? (_newNoteCommand = new MvxCommand(ExecuteNewNoteCommand));

        private void ExecuteNewNoteCommand()
        {
            ShowViewModel<NewNoteViewModel>();
        }
    }
}
