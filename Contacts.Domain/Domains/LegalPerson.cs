using System;
using System.Collections.Generic;

namespace Contacts.Domain.Domains
{
    public class LegalPerson
    {
        public long Id { get; set; }
        public string CompanyName { get; private set; }
        public string TradeName { get; private set; }
        public string CNPJ { get; private set; }

        public Person Person { get; private set; }

        public LegalPerson(string companyName, string tradeName, string cNPJ, string zipCode, string country, string state, string city, string address1, string address2)
        {
            CompanyName = companyName;
            TradeName = tradeName;
            CNPJ = cNPJ;
            Person = new Person(zipCode, country, state, city, address1, address2);
        }

        internal void Update(string companyName, string tradeName, string cnpj, string zipCode, string country, string state, string city, string address1, string address2)
        {
            CompanyName = companyName;
            TradeName = tradeName;
            CNPJ = cnpj;
            Person.Update(zipCode, country, state, city, address1, address2);
        }
    }
}
