using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Licenses.Models
{
    public class Apps
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public int HashCounter { get; set; }
    }
}
