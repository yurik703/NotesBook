using System;
using System.Collections.Generic;
using Notes.Core.Models;

namespace Notes.Core.Interfaces
{
    public interface ILocalStorage
    {
        void AddNote(NoteModel note);
        List<NoteModel> GetNotes();
        NoteModel GetNote(Int64 id);
        void UpdateNote(NoteModel note);
        void RemoveNote(Int64 id);
    }
}
