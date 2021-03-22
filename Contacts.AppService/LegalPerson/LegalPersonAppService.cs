using Contacts.AppService.Models;
using Contacts.Domain;
using System;
using System.Collections.Generic;

namespace Contacts.AppService
{
    public class LegalPersonAppService : ILegalPersonAppService
    {
        private readonly ILegalPersonService legalPersonService;
        public LegalPersonAppService(ILegalPersonService legalPersonService)
        {
            this.legalPersonService = legalPersonService ?? throw new ArgumentNullException("Legal Person Service not found!");
        }

        public List<LegalPersonModel> GetAll()
        {
            var legalPersons = legalPersonService.GetAll();

            var legalPersonModels = new List<LegalPersonModel>();
            foreach (var legalPerson in legalPersons)
                legalPersonModels.Add(new LegalPersonModel(legalPerson));
         
            return legalPersonModels;
        }

        public LegalPersonModel GetById(long id)
        {
            var legalPerson = legalPersonService.GetById(id);
            var model = new LegalPersonModel(legalPerson);
            return model;
        }

        public void Save(LegalPersonModel LegalPersonModel)
        {
            legalPersonService.Save(
                LegalPersonModel.Id,
                LegalPersonModel.CompanyName,
                LegalPersonModel.TradeName,
                LegalPersonModel.CNPJ,
                LegalPersonModel.ZipCode,
                LegalPersonModel.Country,
                LegalPersonModel.State,
                LegalPersonModel.City,
                LegalPersonModel.Address1,
                LegalPersonModel.Address2
            );
        }
    }
}
