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
                phone = string.Empty;
                phone = value.FormatPhone();
                Customer.SetPhone(value);
                onPropertyChanged();
            }
        }
        public string RG
        {
            get => rG;
            set
            {
                rG = string.Empty;
                rG = value.FormatRG();
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
                cPF = string.Empty;
                cPF = value.FormatCPF();
                Customer.SetCpf(value);
                onPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = string.Empty;
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


       

        public void FormatFields()
        {
            
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


            /*
             na passagem de parametro pode ser usado as propriedades da classe 
             ou pode assim passando par de outro elemento

             SearchCommand="{Binding SearchCommand}"
             SearchCommandParameter="{Binding Source={x:Reference searchBar}, Patch=Text}"
            s-> é par
             ClickSaveCommand = new Command(async (s) =>
            {

                if (!BaseModel.IsValid)
                {
                    var messageErrors = string.Empty;
                    foreach (var msg in BaseModel.Notys.Select(x => x.Message))
                        messageErrors += msg + System.Environment.NewLine;
                    await App.Current.MainPage.DisplayAlert("Atenção", messageErrors, "Ok");
                }
                else
                    SaveAction?.Invoke();
            });

             */
            /*
               public DateTime Birthday { get ; private set; }
        public string Phone { get; private set; }
             */
            await App.Current.MainPage.DisplayAlert("Atenção", "Dados Salvos Com Sucesso!", "Ok");
            
        }
    }
}
