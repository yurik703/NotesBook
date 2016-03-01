using System;

namespace Notes.Core.Models
{
    public class NoteModel
    {
        public Int64 Id { get; set; }
        public String Title { get; set; }
        public String Note { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
