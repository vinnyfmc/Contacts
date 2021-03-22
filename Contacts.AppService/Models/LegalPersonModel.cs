using Contacts.Domain.Domains;
using System.ComponentModel.DataAnnotations;

namespace Contacts.AppService.Models
{
    public class LegalPersonModel: AddressModel
    {
        [Required(ErrorMessage = "Id not found")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Company Name cannot be empty")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Trade Name cannot be empty")]
        public string TradeName { get; set; }
        [Required(ErrorMessage = "CNPJ cannot be empty")]
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
