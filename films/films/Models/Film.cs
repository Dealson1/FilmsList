using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace films.Models
{
    public class Film
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public bool View { get; set; }
        public string Commentary { get; set; }
    }
}
