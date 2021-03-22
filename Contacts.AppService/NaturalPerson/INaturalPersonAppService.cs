using Contacts.AppService.Models;
using System.Collections.Generic;

namespace Contacts.AppService
{
    public interface INaturalPersonAppService
    {
        NaturalPersonModel GetById(long id);
        List<NaturalPersonModel> GetAll();
        void Save(NaturalPersonModel naturalPersonModel);
    }
}
