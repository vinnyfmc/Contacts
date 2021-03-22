using Contacts.AppService.Models;
using System.Collections.Generic;

namespace Contacts.AppService
{
    public interface ILegalPersonAppService
    {
        LegalPersonModel GetById(long id);
        List<LegalPersonModel> GetAll();
        void Save(LegalPersonModel legalPersonModel);
    }
}
