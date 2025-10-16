using MitarbeiterVewaltung.Lib.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVewaltung.Lib.Repositories
{
    public interface IRepository
    {
        public void Add(Mitarbeiter mitarbeiter);

        public void Delete(string id);

        public List<Mitarbeiter> GetAll();

        public void Update(string id, string newVorname, string newNachname, int newAlter, string newAbteilung, DateTime newEintrittsDatum, bool newIstVollzeit);
    }
}
