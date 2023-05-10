
using data_bind.Models;
using data_bind.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace data_bind.MVVM.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        BaseModel BaseModel;

        public ReadOnlyCollection<Noty> Notys { get { return BaseModel.Notys; } }
        public bool IsValid { get { return IsValidModel(); } }

        protected virtual bool IsValidModel() => BaseModel.IsValid;

        public ICommand ClickSaveCommand { get; protected set; }


        protected abstract BaseModel  GetBaseModel();

        Func<Task> SaveAction;

        protected abstract Task SaveActionAsync();

        protected BaseViewModel()
        {
            BaseModel = GetBaseModel();
            SaveAction = SaveActionAsync;
            ConfigureSaveViewModel();
        }

          
        private void ConfigureSaveViewModel()
        {
            ClickSaveCommand = new Command(async () =>
            {

                if (!BaseModel.IsValid)
                {
                    var messageErrors = string.Empty;
                    foreach (var msg in BaseModel.Notys.Select(x => x.Message))
                        messageErrors += msg + System.Environment.NewLine;
                    await Application.Current.MainPage.DisplayAlert("Atenção", messageErrors, "Ok");
                }
                else
                    SaveAction?.Invoke();
            });
        }

        protected void onPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
