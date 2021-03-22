using Contacts.Domain.Domains;
using Contacts.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Contacts.Data
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        ObjectCache cache = MemoryCache.Default;
        const string dbName = "LegalPersons";

        public IEnumerable<LegalPerson> GetAll()
        {
            var _LegalPersons = (List<LegalPerson>)cache.Get(dbName);
            if (_LegalPersons == null)
                _LegalPersons = new List<LegalPerson>();

            return _LegalPersons.OrderByDescending(x => x.Id);
        }

        public LegalPerson GetById(long id)
        {
            var _LegalPersons = this.GetAll();
            return _LegalPersons.FirstOrDefault(x => x.Id == id);
        }

        private long GetNextId()
        {
            var _LegalPersons = this.GetAll();
            if (_LegalPersons.Any())
            {
                return _LegalPersons.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            }
            else
                return 1;
        }

        public void Save(LegalPerson legalPerson)
        {
            var _LegalPersons = (List<LegalPerson>)cache.Get(dbName);
            if (_LegalPersons == null)
                _LegalPersons = new List<LegalPerson>();

            if (legalPerson.Id > 0)
            {
                var legalPersonModif = _LegalPersons.FirstOrDefault(x => x.Id == legalPerson.Id);
                _LegalPersons.Remove(legalPersonModif);
            }
            else
                legalPerson.Id = GetNextId();

            _LegalPersons.Add(legalPerson);

            cache.Add(dbName, _LegalPersons, null);
        }

        public IEnumerable<LegalPerson> GetByCNPJ(string cnpj)
        {
            var _LegalPersons = this.GetAll();
            return _LegalPersons.Where(x => x.CNPJ == cnpj);
        }
    }
}
