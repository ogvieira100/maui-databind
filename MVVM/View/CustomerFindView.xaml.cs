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
        CustomerFindViewModel.AddAddresses(new AddressViewModel
        {

            Street = "Rua dos Patos",
            State = Model.State.RJ
        });
        CustomerFindViewModel.AddAddresses(new AddressViewModel
        {

            Street = "das Alcantaras",
            State = Model.State.SP
        });
        //CustomerFindViewModel.AddressViewModels = new List<AddressViewModel>
        //{
        //    new AddressViewModel
        //    {

        //        Street = "Rua dos Patos",
        //        State = Model.State.RJ
        //    },
        //     new AddressViewModel
        //    {

        //        Street = "Rua das Alcantaras",
        //        State = Model.State.SP
        //    }
        //};
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

    private void btnAddAddress_Clicked(object sender, EventArgs e)
    {
        CustomerFindViewModel.AddAddresses(new AddressViewModel
        {
            Street = txtStreet.Text,
            State = pickerState.SelectedItem.ToString().GetEnumToName<Model.State>(Model.State.SP)
        }); ;
    }
}