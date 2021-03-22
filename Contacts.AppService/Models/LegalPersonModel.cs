using Contacts.Domain.Domains;

namespace Contacts.AppService.Models
{
    public class LegalPersonModel: AddressModel
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string CNPJ { get; set; }

        public LegalPersonModel()
        {

        }

        public LegalPersonModel(LegalPerson legalPerson )
        {
            Id = legalPerson.Id;
            CompanyName = legalPerson.CompanyName;
            TradeName = legalPerson.TradeName;
            CNPJ = legalPerson.CNPJ;
            ZipCode = legalPerson.Person?.ZipCode;
            Country = legalPerson.Person?.Country;
            State = legalPerson.Person?.State;
            City = legalPerson.Person?.City;
            Address1 = legalPerson.Person?.Address1;
            Address2 = legalPerson.Person?.Address2;
        }
    }
}
