using data_bind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.Model
{
    public class CustomerModel : BaseModel
    {
        public string CPF { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string RG  { get; private set; }
        public DateTime Birthday { get ; private set; }
        public string Phone { get; private set; }

        
        public TimeSpan LunchTime { get; private set; }

        public bool IsMarried { get; private set; }

        List<AddressModel> _Addresses;
        public ReadOnlyCollection<AddressModel> Addresses { get { return _Addresses.AsReadOnly(); } }

        public void AddAddresses(AddressModel addressModel)
        { 
        
            _Addresses.Add(addressModel);
        }

        public void SetCpf(string cpf)
        {
            CPF = cpf.OnlyNumbers();
        }

        public void SetPhone(string phone)
        {
            Phone = phone.OnlyNumbers();
        }

        public void SetBirthday(DateTime date)
        {
            Birthday = date;
        }



        public void SetRg(string rg)
        {
            RG = rg.OnlyNumbers();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        bool isValidAge()
        {
            if (Age < 18 || Age > 50)
            {
                AddNoty(new Noty
                {
                    Message = " Atenção faixa etária inválida. tem que ter de 18 anos a 50 "
                });
                return false;
            }
            return true;
        }
        bool isValidCPF()
        {
            if (!CPF.IsCpf())
            {
                AddNoty(new Noty
                {
                    Message = "Atenção CPF Inválido"
                }); ;
                return false;
            }
            return true;
        }

        bool isValidName()
        {
            if (string.IsNullOrEmpty(Name) 
                || (!string.IsNullOrEmpty(Name) && (Name.Length < 2 || Name.Length > 30 )))
            {
                AddNoty(new Noty
                {
                    Message = "Atenção Nome Inválido"
                }); ;
                return false;
            }
            return true;
        }



        protected override bool IsValidModel()
        {
            ClearNoty();
            return
                   isValidCPF()
            && isValidAge()
            && isValidName();
        }
            
            
            

        public void SetIsMarried(bool value)
        {
            IsMarried = value;
        }

        public void SetLunchTime(TimeSpan value)
        {
            LunchTime = value;
        }

        public CustomerModel()
        {
            _Addresses = new List<AddressModel>();
        }

        public CustomerModel(string cPF, string name, int age)
            :base()
        {
            CPF = cPF;
            Name = name;
            Age = age;
        }
    }
}
