using data_bind.Models;
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
        => ValidStreet() && ValidState();

        bool ValidStreet()
        {
            if (string.IsNullOrEmpty(Street))
            {
                AddNoty(new Noty
                    {
                        Message = "Atenção Nome Inválido"
                    });
                return false;
            }

            return true;
        }



        bool ValidState()
        {
            if (!Enum.IsDefined(typeof(State), State))
            {
                AddNoty(new Noty
                {
                    Message = "Atenção Estado Inválido"
                });
                return false;
            }
            return true;
        }


        
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
