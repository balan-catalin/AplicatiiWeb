using Proiect_TWB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proiect_TWB.Controllers
{
    public class PersonController : ApiController
    {
        private List<Person> GenerareListaPers()
        {
            var lista = new List<Person>();
            lista.Add(new Person() { id = 1, Nume = "Balan", Prenume = "Catalin", DataNastere = DateTime.Parse("06/02/1997", new CultureInfo("en-US", true)), Adresa = new Adresa() { Oras = "Brasov", Localitate = "Bod", Strada = "Garii", Numar = "42" }, CNP = "1970602080010" });
            lista.Add(new Person() { id = 2, Nume = "Duma", Prenume = "Vlad", DataNastere = DateTime.Parse("12/12/1997", new CultureInfo("en-US", true)), Adresa = new Adresa() { Oras = "Constanta", Localitate = "Mamaia", Strada = "Petuniei", Numar = "14" }, CNP = "1971216080016" });
            lista.Add(new Person() { id = 3, Nume = "Branzea", Prenume = "Bianca", DataNastere = DateTime.Parse("06/01/1995", new CultureInfo("en-US", true)), Adresa = new Adresa() { Oras = "Fagaras", Localitate = "Fagaras", Strada = "Florilor", Numar = "245" }, CNP = "2970628080010" });
            lista.Add(new Person() { id = 4, Nume = "Barbalata", Prenume = "Alexandru", DataNastere = DateTime.Parse("10/07/2000", new CultureInfo("en-US", true)), Adresa = new Adresa() { Oras = "Brasov", Localitate = "Bod", Strada = "Harmanului", Numar = "400" }, CNP = "1970602080010" });
            return lista;
        }

        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Person
        [HttpPost]
        public bool Post(Person value)
        {
            var list = GenerareListaPers();
            try
            {
                list.Add(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Person/5
        [HttpPut]
        public bool Put(int PersId, Person value)
        {
            var list = GenerareListaPers();
            Person PersFind = list.Find(x => x.id == PersId);
            if (PersFind == null)
                return false;
            PersFind = value;
            return true;
        }

        // DELETE: api/Person/5
        [HttpDelete]
        public bool Delete(int PersId)
        {
            var list = GenerareListaPers();
            list.RemoveAll(x => x.id == PersId);
            return true;
        }

        [HttpGet]
        public Person GetPerson(int id)
        {
            Person person = new Person();
            person.id = 1;
            person.Nume = "Balan";
            person.Prenume = "Catalin";
            person.DataNastere = DateTime.Parse("06/02/1997", new CultureInfo("en-US", true));
            person.Adresa = new Adresa() { Oras="Brasov", Localitate="Bod", Strada="Garii", Numar="42" };
            person.CNP = "1970602080010";
            return person;
        }

        [HttpGet]
        public List<Person> ListaPersoanaFctDeAn(int An)
        {
            var lista = GenerareListaPers();
            var rez = lista.Where(x => x.DataNastere.Year == An).ToList();
            return rez;
        }
        

        [HttpPost]
        public int AddPers(Person p)
        {
            var lista = GenerareListaPers();
            try
            {
                lista.Add(p);
            }
            catch { }
            return p.id;
        }
    }
}
