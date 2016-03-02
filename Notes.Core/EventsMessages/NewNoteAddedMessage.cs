using MvvmCross.Plugins.Messenger;

namespace Notes.Core.EventsMessages
{
    public class NewNoteAddedMessage : MvxMessage
    {
        public NewNoteAddedMessage(object sender) : base(sender)
        {
        }
    }
}
