using Contacts.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Domain
{
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly INaturalPersonRepository naturalPersonRepository;
        public NaturalPersonService(INaturalPersonRepository naturalPersonRepository)
        {
            this.naturalPersonRepository = naturalPersonRepository ?? throw new ArgumentNullException("Natural Person Repository not found!");
        }

        public IEnumerable<NaturalPerson> GetAll()
        {
            return naturalPersonRepository.GetAll();
        }

        public NaturalPerson GetById(long Id)
        {
            return naturalPersonRepository.GetById(Id);
        }

        public void Save(
            long id, 
            string name, 
            DateTime birthday, 
            string cpf, 
            int gender, 
            string zipCode, 
            string country, 
            string state, 
            string city, 
            string address1, 
            string address2)
        {
            if (!CpfIsValid(cpf))
                throw new ArgumentException("CPF - Invalid!");
            else
            {
                var naturalPersonCpf = naturalPersonRepository.GetByCPF(cpf);
                if (naturalPersonCpf.Any(x => x.Id != id))
                    throw new ArgumentException("CPF - Already exists!");
            }

            NaturalPerson naturalPerson = null;
            if (id == 0)
            {
                naturalPerson = new NaturalPerson(
                    name,
                    cpf,
                    birthday,
                    gender,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }
            else
            {
                naturalPerson = GetById(id);
                naturalPerson.Update(name,
                    cpf,
                    birthday,
                    gender,
                    zipCode,
                    country,
                    state,
                    city,
                    address1,
                    address2);
            }

            naturalPersonRepository.Save(naturalPerson);
        }

        private bool CpfIsValid(string cpfcnpj)
        {
            var _cpf = OnlyNumbers(cpfcnpj.Trim());
            if (_cpf.Length == 11)
                return CpfCheck(_cpf);
            else
                throw new ArgumentException("CNPJ - wrong format!");
        }

        private string OnlyNumbers(string texto)
        {
            return new string(texto.Where(char.IsDigit).ToArray());
        }

        private bool CpfCheck(string cpf)
        {
            int[] m1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * m1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * m2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }


    }
}
