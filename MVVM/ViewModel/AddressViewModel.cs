using data_bind.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.ViewModel
{
    public class AddressViewModel : BaseViewModel
    {
        private string street;
        private State state;

        public AddressModel Addresses { get; private set; }

        public string Street { get => street; set
            {
                street = value;
                Addresses.SetStreet(value);
                onPropertyChanged();
            }
        }
        public State State { get => state; set
            {
                state = value;
                Addresses.SetState(value);
                onPropertyChanged();
            }
        }


        protected override BaseModel GetBaseModel()
        {
            Addresses = new AddressModel();
            return Addresses;
        }

        protected override async Task SaveActionAsync()
        {
            await Task.FromResult(0);
        }
    }
}
