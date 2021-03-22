using Contacts.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Contacts.Domain
{
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly INaturalPersonRepository naturalPersonRepository;
        public NaturalPersonService(INaturalPersonRepository naturalPersonRepository)
        {
            this.naturalPersonRepository = naturalPersonRepository ?? throw new ArgumentNullException("Natural Person Repository not found!");
        }

        public IEnumerable<NaturalPerson> GetAll()
        {
            return naturalPersonRepository.GetAll();
        }

        public NaturalPerson GetById(long Id)
        {
            return naturalPersonRepository.GetById(Id);
        }

        public void Save(
            long id, 
            string name, 
            DateTime birthday, 
            string cpf, 
            int gender, 
            string zipCode, 
            string country, 
            string state, 
            string city, 
            string address1, 
            string address2)
        {
            NaturalPerson naturalPerson = null;
            if (id == 0)
            {
                naturalPerson = new NaturalPerson(
                    name,
                    cpf,
                    birthday,
                    gender,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }
            else
            {
                naturalPerson = GetById(id);
                naturalPerson.Update(name,
                    cpf,
                    birthday,
                    gender,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }

            naturalPersonRepository.Save(naturalPerson);
        }
    }
}
