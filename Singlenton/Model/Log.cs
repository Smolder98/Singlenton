using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Singlenton.Model
{
    public class Log
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
    }
}
