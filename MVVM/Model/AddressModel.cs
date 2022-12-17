using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.Model
{
    public enum State
    { 
        SP,
        RJ,
        MG
    }
    public class AddressModel : BaseModel
    {
        public string Street { get; private set; }
        public State State { get; private set; }

        protected override bool IsValidModel()
        => true;

        public void SetState(State value)
        {
            State = value;
        }

        public void SetStreet(string value)
        {
            Street = value;
        }

        public AddressModel()
        {
            State = State.SP;
        }

        public AddressModel(string street, State state)
            :base()
        {
            Street = street;
            State = state;
        }
    }
}
