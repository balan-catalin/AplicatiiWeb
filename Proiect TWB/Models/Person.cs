using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect_TWB.Models
{
    public class Person
    {
        public int id { get; set; }
        public String Nume { get; set; }
        public String Prenume { get; set; }
        public DateTime DataNastere { get; set; }
        public Adresa Adresa { get; set; }
        public String CNP { get; set; }
    }
}