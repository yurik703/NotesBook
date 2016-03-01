using System;
using SQLite.Net.Attributes;

namespace Notes.Database.Schema
{
    [Table("Notes")]
    public class LocalNote
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public Int64 Id { get; set; }
        public String Title { get; set; }
        public String Note { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
