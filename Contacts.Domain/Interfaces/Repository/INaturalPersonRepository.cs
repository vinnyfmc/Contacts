using System.Collections.Generic;

namespace Contacts.Domain.Interfaces.Repository
{
    public interface INaturalPersonRepository
    {
        NaturalPerson GetById(long Id);
        IEnumerable<NaturalPerson> GetAll();
        void Save(NaturalPerson naturalPerson);
    }
}
