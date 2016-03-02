using MvvmCross.Plugins.Messenger;

namespace Notes.Core.EventsMessages
{
    public class ApplicationInitializedMessage : MvxMessage
    {
        public ApplicationInitializedMessage(object sender) : base(sender)
        {
        }
    }
}
