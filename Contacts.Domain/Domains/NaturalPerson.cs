using System;

namespace Contacts.Domain
{
    public class NaturalPerson
    {
        public long Id { get; set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public DateTime Birthday { get; private set; }
        public int Gender { get; private set; }

        public Person Person { get; private set; }

        public NaturalPerson(
            string name, 
            string cpf, 
            DateTime birthday, 
            int gender, 
            string zipCode, 
            string country, 
            string state, 
            string city, 
            string address1, 
            string address2)
        {
            Name = name;
            CPF = cpf;
            Birthday = birthday;
            Gender = gender;
            Person = new Person(zipCode, country, state, city, address1, address2);
        }

        public void Update (
            string name,
            string cpf,
            DateTime birthday,
            int gender,
            string zipCode,
            string country,
            string state,
            string city,
            string address1,
            string address2)
        {
            Name = name;
            CPF = cpf;
            Birthday = birthday;
            Gender = gender;
            Person.Update(zipCode, country, state, city, address1, address2);
        }

    }
}
