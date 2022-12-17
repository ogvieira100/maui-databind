
using data_bind.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        BaseModel BaseModel;

        protected abstract BaseModel  GetBaseModel();

        Func<Task> SaveAction;

        protected abstract Task SaveActionAsync();

        protected BaseViewModel()
        {
            BaseModel = GetBaseModel();
            SaveAction = SaveActionAsync;
        }

        protected void onPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
