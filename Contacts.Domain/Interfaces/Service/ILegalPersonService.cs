using Contacts.Domain.Domains;
using System.Collections.Generic;

namespace Contacts.Domain
{
    public interface ILegalPersonService
    {
        LegalPerson GetById(long Id);
        IEnumerable<LegalPerson> GetAll();
        void Save(
            long id, 
            string companyName, 
            string tradeName, 
            string cNPJ, 
            string zipCode, 
            string country, 
            string state, 
            string city, 
            string address1,
            string address2);
    }
}
