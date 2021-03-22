using Contacts.Domain;
using Contacts.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Contacts.Data
{
    public class NaturalPersonRepository : INaturalPersonRepository
    {
        ObjectCache cache = MemoryCache.Default;
        const string dbName = "NaturalPersons";

        public IEnumerable<NaturalPerson> GetAll()
        {
            var _NaturalPersons = (List<NaturalPerson>)cache.Get(dbName);
            if (_NaturalPersons == null)
                _NaturalPersons = new List<NaturalPerson>();

            return _NaturalPersons.OrderByDescending(x => x.Id);
        }

        public NaturalPerson GetById(long id)
        {
            var _NaturalPersons = this.GetAll();
            return _NaturalPersons.FirstOrDefault(x => x.Id == id);
        }

        private long GetNextId()
        {
            var _NaturalPersons = this.GetAll();
            if (_NaturalPersons.Any())
            {
                return _NaturalPersons.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            }
            else
                return 1;
        }

        public void Save(NaturalPerson naturalPerson)
        {
            var _NaturalPersons = (List<NaturalPerson>)cache.Get(dbName);
            if (_NaturalPersons == null)
                _NaturalPersons = new List<NaturalPerson>();

            if (naturalPerson.Id > 0)
            {
                var naturalPersonModif = _NaturalPersons.FirstOrDefault(x => x.Id == naturalPerson.Id);
                _NaturalPersons.Remove(naturalPersonModif);
            }
            else
                naturalPerson.Id = GetNextId();
           
            _NaturalPersons.Add(naturalPerson);

            cache.Add(dbName, _NaturalPersons, null);
        }

        public IEnumerable<NaturalPerson> GetByCPF(string cpf)
        {
            var _NaturalPersons = this.GetAll();
            return _NaturalPersons.Where(x => x.CPF == cpf);
        }
    }
}
