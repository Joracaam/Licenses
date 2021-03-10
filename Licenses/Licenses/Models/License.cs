using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Licenses.Models
{
    public class License
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SerialCode { get; set; }
        public string LicenseCode { get; set; }
        public DateTime EmissionDate { get; set; }
    }
}
