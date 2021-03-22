using System.Collections.Generic;

namespace Contacts.Domain.Interfaces.Repository
{
    public interface INaturalPersonRepository
    {
        NaturalPerson GetById(long id);
        IEnumerable<NaturalPerson> GetAll();
        IEnumerable<NaturalPerson> GetByCPF(string cpf);
        void Save(NaturalPerson naturalPerson);
    }
}
