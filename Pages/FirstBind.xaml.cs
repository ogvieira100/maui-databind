using data_bind.Models;

namespace data_bind.Pages;

public partial class FirstBind : ContentPage
{
	public FirstBind()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var person = new Person { 
			Name="Osmar Gonçalves Vieira",
			Phone = "(11) 9491-75613",
			Address = "Rua Planalto dos Acantilados nº 93"
		};
		Binding personBinding = new Binding();
		personBinding.Source = person;
		personBinding.Path = "Name";

        Binding personBindingPhone = new Binding();
        personBindingPhone.Source = person;
        personBindingPhone.Path = "Phone";

        Binding personBindingAddress = new Binding();
        personBindingAddress.Source = person;
        personBindingAddress.Path = "Address";


        txtName.SetBinding(Label.TextProperty, personBinding);
        txtPhone.SetBinding(Label.TextProperty, personBindingPhone);
        txtAddress.SetBinding(Label.TextProperty, personBindingAddress);

    }
}