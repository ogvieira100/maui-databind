using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.Models
{
     public class Person:INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        { 
            get => _name;
            set { 
            _name = value;
             onPropertyChanged();
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                onPropertyChanged();
            }
        }


        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                onPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void onPropertyChanged([CallerMemberName] string propName= null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propName));
        }
    }
}
