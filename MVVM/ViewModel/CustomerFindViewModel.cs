using data_bind.Models;
using data_bind.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.ViewModel
{
    public class CustomerFindViewModel : BaseViewModel
    {
        private string cPF;
        private string name;
        private int age;
        private string phone;
        private string rG;
        private DateTime birthday;
        private bool isMarried;
        private TimeSpan lunchTime;


        List<AddressViewModel> Addresses = new List<AddressViewModel>();
        public  ReadOnlyCollection<AddressViewModel> AddressViewModels { get { return Addresses.AsReadOnly(); } }
        public CustomerModel Customer { get; private set; }

        public void AddAddresses(AddressViewModel addressViewModel)
        {
            Addresses.Add(addressViewModel);
            Customer.AddAddresses(new AddressModel(street: addressViewModel.Street,state: addressViewModel.State));
            onPropertyChanged();
        }

        public bool IsMarried
        {
            get => isMarried; set
            {
                isMarried = value;
                Customer.SetIsMarried(value);
                onPropertyChanged();
            }
        }

        public TimeSpan LunchTime { get => lunchTime;
            set
            {
                lunchTime = value;
                Customer.SetLunchTime(value);
                onPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone;

            set
            {
                phone = value;
                Customer.SetPhone(value);
                onPropertyChanged();
            }
        }
        public string RG
        {
            get => rG;
            set
            {
                rG = value;
                Customer.SetRg(value);
                onPropertyChanged();
            }
        }
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                Customer.SetBirthday(value);
                onPropertyChanged();
            }
        }



        public string CPF
        {
            get => cPF;
            set
            {
                cPF = value;
                Customer.SetCpf(value);
                onPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                Customer.SetName(name);
                onPropertyChanged();
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                Customer.SetAge(age);
                onPropertyChanged();
            }
        }


        public void FormatCPF() => CPF = cPF.FormatCPF();

        public void FormatRg() => RG = rG.FormatRG();

        public void FormatPhone() => Phone = phone.FormatPhone();

        public void FormatFields()
        {
            FormatCPF();
            FormatRg();
            FormatPhone();
        }
        public CustomerFindViewModel()
        {

            Birthday = DateTime.Now;
            
        }

        protected override BaseModel GetBaseModel()
        {
            Customer = new CustomerModel();
            return Customer;
        }

        public CustomerModel GetModel()
        {

            return Customer;

        }
        /*
         * Salvar Customer Event 
         */
        protected async override Task SaveActionAsync()
        {
            await Task.FromResult(0);
        }
    }
}
