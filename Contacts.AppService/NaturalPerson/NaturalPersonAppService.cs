using System;
using System.Collections.Generic;
using Contacts.AppService.Models;
using Contacts.Domain;

namespace Contacts.AppService
{
    public class NaturalPersonAppService : INaturalPersonAppService
    {
        private readonly INaturalPersonService naturalPersonService;
        public NaturalPersonAppService(INaturalPersonService naturalPersonService)
        {
            this.naturalPersonService = naturalPersonService ?? throw new ArgumentNullException("Natural Person Service not found!");
        }

        public NaturalPersonModel GetById(long id)
        {
            var naturalPerson = naturalPersonService.GetById(id);
            var model = new NaturalPersonModel(naturalPerson);
            return model;
        }

        public List<NaturalPersonModel> GetAll()
        {
            var naturalPersons = naturalPersonService.GetAll();

            var naturalPersonModels = new List<NaturalPersonModel>();
            foreach (var naturalPerson in naturalPersons)
                naturalPersonModels.Add(new NaturalPersonModel(naturalPerson));
            
            return naturalPersonModels;
        }

        public void Save(NaturalPersonModel naturalPersonModel)
        {
            naturalPersonService.Save(
                naturalPersonModel.Id,
                naturalPersonModel.Name,
                Convert.ToDateTime(naturalPersonModel.Birthday),
                naturalPersonModel.CPF,
                naturalPersonModel.Gender,
                naturalPersonModel.ZipCode,
                naturalPersonModel.Country,
                naturalPersonModel.State,
                naturalPersonModel.City,
                naturalPersonModel.Address1,
                naturalPersonModel.Address2
            );;
        }
    }
}
