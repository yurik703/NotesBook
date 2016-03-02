using System;
using MvvmCross.Plugins.Messenger;
using Notes.Core.Models;

namespace Notes.Core.EventsMessages
{
    public class UpdateNoteMessage : MvxMessage
    {
        public NoteModel Note { get; set; }
        public UpdateNoteMessage(object sender, NoteModel note) : base(sender)
        {
            Note = note;
        }
    }
}
