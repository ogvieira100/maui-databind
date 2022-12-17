
namespace data_bind.Pages;

public partial class SixBind : ContentPage
{

    public data_bind.Models.Person Person { get; set; }
    public SixBind()
    {
        InitializeComponent();
        InitializePerson();
    }

    private void InitializePerson()
    {
        Person = new data_bind.Models.Person
        {
            Address = "Rua Tal",
            Name = "Osmar",
            Phone = "(11) 94917-5613"
        };
        BindingContext = Person;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var rand = new Random();
        string[] names = { "Osmar", "Patricia", "Rodrigo", "Manuel" };
        string[] addresses = { "Rua Tupi", "Rua Aracaju", "Rua Piaba" };
        string[] phones = { "(11) 3341-4646", "(11) 3341-4747", "(11) 3341-4848" };

        var nameChoice  =  names[rand.Next(names.Length)] ;
        var phoneChoice =  phones[rand.Next(phones.Length)];
        var addressChoice = addresses[rand.Next(addresses.Length)];

        Person.Name = nameChoice;
        Person.Address = addressChoice;
        Person.Phone = phoneChoice; 

    }
}