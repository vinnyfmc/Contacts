using System;

namespace Contacts.Domain
{
    public class Person
    {
        public long Id { get; private set; }

        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }

        public Person(string zipCode, string country, string state, string city, string address1, string address2)
        {
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            Address1 = address1;
            Address2 = address2;
        }

        internal void Update(string zipCode, string country, string state, string city, string address1, string address2)
        {
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            Address1 = address1;
            Address2 = address2;
        }
    }
}
