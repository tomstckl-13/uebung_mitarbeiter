using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVewaltung.Lib.Modell
{
    public class Mitarbeiter
    {
        public string Id { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public int Alter { get; set; }

        public string Abteilung { get; set; }

        public DateTime Eintrittsdatum { get; set; }

        public bool IstVollzeit { get; set; }

        public Mitarbeiter(string vorname, string nachname, int alter, string abteilung, DateTime eintrittsDatum, bool istVollzeit)
        {
            this.Id = Guid.NewGuid().ToString();    
            this.Alter = alter;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Abteilung = abteilung;
            this.Eintrittsdatum = eintrittsDatum;
            this.IstVollzeit = istVollzeit;

        }

        public Mitarbeiter(string id, string vorname, string nachname, int alter, string abteilung, DateTime eintrittsDatum, bool istVollzeit)
        {
            this.Id = id;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Alter = alter;
            this.Abteilung = abteilung;
            this.Eintrittsdatum = eintrittsDatum;
            this.IstVollzeit = istVollzeit;
        }
    }
}
