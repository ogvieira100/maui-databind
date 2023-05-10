using data_bind.Models;
using data_bind.MVVM.ViewModel;

namespace data_bind.MVVM.View;

public partial class CustomerFindView : ContentPage
{

    public CustomerFindViewModel CustomerFindViewModel { get; set; }
    public CustomerFindView()
    {
        InitializeComponent();

        CustomerFindViewModel = new CustomerFindViewModel();
        CustomerFindViewModel.CPF = "21371885893";
        CustomerFindViewModel.RG = "299463680";
        CustomerFindViewModel.Age = 10;
        CustomerFindViewModel.LunchTime = new TimeSpan(15, 30, 00);
        CustomerFindViewModel.Birthday = DateTime.Now.AddYears(-10);
        CustomerFindViewModel.IsMarried = true;
        CustomerFindViewModel.Phone = "551133414646";
        CustomerFindViewModel.Name = "Osmar Gonçalves Vieira";

        CustomerFindViewModel.AddAddresses(new AddressViewModel
        {
            Street = "Rua dos Patos",
            State = Model.State.RJ
        });
        CustomerFindViewModel.AddAddresses(new AddressViewModel
        {

            Street = "das Alcantaras",
            State = Model.State.SP
        }
        );
       BindingContext = CustomerFindViewModel;
    }




    private void Button_Clicked(object sender, EventArgs e)
    {
        var customer = CustomerFindViewModel.GetModel();
        if (customer.IsValid)
        {



        }
    }


    private void btnMaskFields_Clicked(object sender, EventArgs e)
    {
        CustomerFindViewModel.FormatFields();
    }

    private async void btnAddAddress_Clicked(object sender, EventArgs e)
    {
        var selectedItem = "0";
        if (pickerState.SelectedItem is not null)
            selectedItem = pickerState.SelectedItem.ToString();

        var address = new AddressViewModel
        {
            Street = txtStreet.Text,
            State = selectedItem.GetEnumToName<Model.State>(Model.State.SP)
        };
        if (address.IsValid)
        {
            CustomerFindViewModel.AddAddresses(address);
            colAddress.ItemsSource = CustomerFindViewModel.AddressViewModels;
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Atenção", string.Join(',', address.Notys.Select(x => x.Message)), "Ok");
        }
    }
}