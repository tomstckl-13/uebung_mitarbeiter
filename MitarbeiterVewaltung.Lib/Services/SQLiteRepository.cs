using Microsoft.EntityFrameworkCore;
using MitarbeiterVewaltung.Lib.Context;
using MitarbeiterVewaltung.Lib.Modell;
using MitarbeiterVewaltung.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVewaltung.Lib.Services
{
    public class SQLiteRepository : IRepository
    {

        private string _path;

        public SQLiteRepository(string path)
        {
            _path = path;

        }

        public void Add(Mitarbeiter mitarbeiter)
        {
            using (var context = new MitarbeiterContext(_path))
            {
                context.Add(mitarbeiter);
                context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            try
            {
                using (var context = new MitarbeiterContext(_path))
                {
                    context.Database
                        .ExecuteSqlRaw("DELETE FROM Mitarbeiterinnen WHERE Id={0}",
                        id);
                }

                
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public List<Mitarbeiter> GetAll()
        {
            try
            {
                using (var context = new MitarbeiterContext(_path))
                {
                    /*
                    var to = "Saalfelden";
*/
                    var mitarbeiter = context.Mitarbeiterinnen.FromSql
                        ($"SELECT * FROM Mitarbeiterinnen").ToList();

                    return mitarbeiter;
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Mitarbeiter>();
            }
        }

        public void Update(string id, string newVorname, string newNachname, int newAlter, string newAbteilung, DateTime newEintrittsDatum, bool newIstVollzeit)
        {
            try
            {
                using(var context = new MitarbeiterContext(_path))
                {
                    var mitarbeiter = context.Mitarbeiterinnen.Find(id);
                    if(mitarbeiter != null)
                    {
                        mitarbeiter.Vorname = newVorname;
                        mitarbeiter.Nachname = newNachname;
                        mitarbeiter.Alter = newAlter;
                        mitarbeiter.Abteilung = newAbteilung;
                        mitarbeiter.EintrittsDatum = newEintrittsDatum;
                        mitarbeiter.IstVollzeit = newIstVollzeit;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            
            }
        }
    }
}
