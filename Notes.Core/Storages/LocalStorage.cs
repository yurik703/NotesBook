using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Notes.Core.Interfaces;
using Notes.Core.Models;
using Notes.Database;
using Notes.Database.Schema;

namespace Notes.Core.Storages
{
    public class LocalStorage : ILocalStorage
    {
        private readonly DataRepository _repository = new DataRepository();

        public void AddNote(NoteModel note)
        {
            var locatNote = Mapper.Map<LocalNote>(note);
            _repository.AddNote(locatNote);
        }

        public List<NoteModel> GetNotes()
        {
            var locatNotes = _repository.GetNotes();
            var noteModels = Mapper.Map<IEnumerable<LocalNote>, IEnumerable<NoteModel>>(locatNotes);
            return noteModels.ToList();
        }

        public NoteModel GetNote(long id)
        {
            var localNote = _repository.GetNote(id);
            return Mapper.Map<NoteModel>(localNote);
        }

        public void UpdateNote(NoteModel note)
        {
            var locatNote = Mapper.Map<LocalNote>(note);
            _repository.UpdateNote(locatNote);
        }

        public void RemoveNote(long id)
        {
            _repository.RemoveNote(id);
        }
    }
}
