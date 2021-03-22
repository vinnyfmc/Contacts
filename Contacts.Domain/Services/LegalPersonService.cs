using Contacts.Domain.Domains;
using Contacts.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Contacts.Domain
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ILegalPersonRepository legalPersonRepository;
        public LegalPersonService(ILegalPersonRepository legalPersonRepository)
        {
            this.legalPersonRepository = legalPersonRepository ?? throw new ArgumentNullException("Legal Person Repository not found!");
        }

        public IEnumerable<LegalPerson> GetAll()
        {
            return legalPersonRepository.GetAll();
        }

        public LegalPerson GetById(long Id)
        {
            return legalPersonRepository.GetById(Id);
        }

        public void Save(
            long id, 
            string companyName, 
            string tradeName, 
            string cnpj, 
            string zipCode, 
            string country, 
            string state, 
            string city,
            string address1, 
            string address2)
        {
            LegalPerson legalPerson = null;
            if (id == 0)
            {
                legalPerson = new LegalPerson(
                    companyName,
                    tradeName,
                    cnpj,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }
            else
            {
                legalPerson = GetById(id);
                legalPerson.Update(
                    companyName,
                    tradeName,
                    cnpj,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }

            legalPersonRepository.Save(legalPerson);
        }
    }
}
