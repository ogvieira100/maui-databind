using data_bind.Models;

namespace data_bind.Pages;

public partial class ThirdBind : ContentPage
{
	public ThirdBind()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var person = new Person
        {
            Name = "Osmar Gonçalves Vieira",
            Phone = "(11) 9491-75613",
            Address = "Rua Planalto dos Acantilados nº 93"
        };

        /*associando ao contexto da pagina*/
        BindingContext = person;
        /*associando ao contexto do elemento*/
        txtName.BindingContext = person;
        //Associando pelo codBehind pode ser feito pela pagina
        // Text="{Binding Address}"
        //txtName.SetBinding(Label.TextProperty, "Name");

    }
}