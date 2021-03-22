using System;
using System.Collections.Generic;

namespace Contacts.Domain
{
    public interface INaturalPersonService
    {
        NaturalPerson GetById(long Id);
        IEnumerable<NaturalPerson> GetAll();
        void Save(
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
            string address2);
    }
}
