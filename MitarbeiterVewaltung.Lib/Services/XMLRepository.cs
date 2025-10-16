using MitarbeiterVewaltung.Lib.Modell;
using MitarbeiterVewaltung.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MitarbeiterVewaltung.Lib.Services
{
    public class XMLRepository : IRepository
    {
        XElement _rootElement;
        private string _path;

        public XMLRepository(string path)
        {
            _path = path;
            if(File.Exists(_path))
            {
                _rootElement = XElement.Load(_path);
            }
            else
            {
                _rootElement = new XElement("mitarbeiterinnen");
            }
        }

        public void Add(Mitarbeiter mitarbeiter)
        {
            XElement node = new XElement("mitarbeiter");
            var idAttrib = new XAttribute("id", mitarbeiter.Id.ToString());
            node.Add(idAttrib);

            var vorNameAttrib = new XAttribute("vorname", mitarbeiter.Vorname.ToString());
            node.Add(vorNameAttrib);

            var nachNameAttrib = new XAttribute("nachname", mitarbeiter.Nachname.ToString());
            node.Add(nachNameAttrib);

            var alterAttrib = new XAttribute("alter", mitarbeiter.Alter.ToString());
            node.Add(alterAttrib);

            var abteilungAttrib = new XAttribute("abteilung", mitarbeiter.Abteilung.ToString());
            node.Add(abteilungAttrib);

            var eintrittAttrib = new XAttribute("eintritt", mitarbeiter.Eintrittsdatum.ToString());
            node.Add(eintrittAttrib);

            var istVollzeitAttrib = new XAttribute("vollzeit", mitarbeiter.IstVollzeit.ToString());
            node.Add(istVollzeitAttrib);

            _rootElement.Add(node);
            _rootElement.Save(_path);


        }

        public void Delete(string id)
        {
            var itemsTodelete = from e in this._rootElement.Descendants("mitarbeiter")
                                where e.Attribute("id").Value == id
                                select e;
            itemsTodelete.Remove();
            _rootElement.Save(_path);
        }

        public List<Mitarbeiter> GetAll()
        {
            var mitarbeiter = from e in this._rootElement.Descendants("mitarbeiter")
                              select new Mitarbeiter(
                                    e.Attribute("id").Value,
                                    e.Attribute("vorname").Value,
                                    e.Attribute("nachname").Value,
                                    (int)e.Attribute("alter"),
                                    e.Attribute("abteilung").Value,
                                    Convert.ToDateTime(e.Attribute("eintrittsdatum").Value),
                                    Convert.ToBoolean(e.Attribute("vollzeit").Value)


                                  );

            return mitarbeiter.ToList<Mitarbeiter>();
        }

        public void Update(string id, string newVorname, string newNachname, int newAlter, string newAbteilung, DateTime newEintrittsDatum, bool newIstVollzeit)
        {
            var mitarbeiterToUpdate = (from e in this._rootElement.Descendants("mitarbeiter")
                                      where e.Attribute("id").Value == id
                                      select e).FirstOrDefault();

            if(mitarbeiterToUpdate != null)
            {
                mitarbeiterToUpdate.SetAttributeValue("vorname", newVorname.ToString());
                mitarbeiterToUpdate.SetAttributeValue("nachname", newNachname.ToString());
                mitarbeiterToUpdate.SetAttributeValue("alter", newAlter.ToString());
                mitarbeiterToUpdate.SetAttributeValue("abteilung", newAbteilung.ToString());
                mitarbeiterToUpdate.SetAttributeValue("eintrittsdatum", newEintrittsDatum.ToString());
                mitarbeiterToUpdate.SetAttributeValue("vollzeit", newIstVollzeit.ToString());

                _rootElement.Save(_path);
            }
        }
    }
}
