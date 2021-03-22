using Contacts.Domain.Domains;
using Contacts.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Domain
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ILegalPersonRepository legalPersonRepository;
        public LegalPersonService(ILegalPersonRepository legalPersonRepository)
        {
            this.legalPersonRepository = legalPersonRepository ?? throw new ArgumentNullException("Legal Person Repository not found!");
        }

        public IEnumerable<LegalPerson> GetAll()
        {
            return legalPersonRepository.GetAll();
        }

        public LegalPerson GetById(long Id)
        {
            return legalPersonRepository.GetById(Id);
        }

        public void Save(
            long id, 
            string companyName, 
            string tradeName, 
            string cnpj, 
            string zipCode, 
            string country, 
            string state, 
            string city,
            string address1, 
            string address2)
        {
            if (!CnpjIsValid(cnpj))
                throw new ArgumentException("CNPJ - Invalid!");
            else
            {
                var legalPersonCnpj = legalPersonRepository.GetByCNPJ(cnpj);
                if(legalPersonCnpj.Any(x => x.Id != id ))
                    throw new ArgumentException("CNPJ - Already exists!");
            }

            LegalPerson legalPerson = null;
            if (id == 0)
            {
                legalPerson = new LegalPerson(
                    companyName,
                    tradeName,
                    cnpj,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }
            else
            {
                legalPerson = GetById(id);
                legalPerson.Update(
                    companyName,
                    tradeName,
                    cnpj,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }

            legalPersonRepository.Save(legalPerson);
        }

        private bool CnpjIsValid(string cnpj)
        {
            var _cnpj = OnlyNumbers(cnpj.Trim());
            if (_cnpj.Length == 14)
                return CnpjCheck(_cnpj);
            else
                throw new ArgumentException("CNPJ - wrong format!");
        }

        private string OnlyNumbers(string texto)
        {
            return new string(texto.Where(char.IsDigit).ToArray());
        }

        private bool CnpjCheck(string cnpj)
        {
            int[] m1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * m1[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * m2[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
        }

    }
}
