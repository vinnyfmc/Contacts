using Contacts.Domain;
using System;

namespace Contacts.AppService.Models
{
    public class NaturalPersonModel : AddressModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Birthday { get; set; }
        public int Gender { get; set; }

        public AddressModel AddressModel { get; set; }

        public NaturalPersonModel()
        {

        }

        public NaturalPersonModel(NaturalPerson naturalPerson)
        {
            Id = naturalPerson.Id;
            Name = naturalPerson.Name;
            CPF = naturalPerson.CPF;
            Birthday = naturalPerson.Birthday.ToString("yyyy-MM-dd");
            Gender = naturalPerson.Gender;
            ZipCode = naturalPerson.Person?.ZipCode;
            Country = naturalPerson.Person?.Country;
            State = naturalPerson.Person?.State;
            City = naturalPerson.Person?.City;
            Address1 = naturalPerson.Person?.Address1;
            Address2 = naturalPerson.Person?.Address2;
        }
    }
}
