using data_bind.MVVM.View;
using data_bind.Pages;

namespace data_bind;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void btnFirstBind_Clicked(object sender, EventArgs e)
    {
		 await Navigation.PushAsync(new FirstBind());
    }

    private async void btnSecondBind_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new XamlBind());
    }

    private async void btnTirdBind_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ThirdBind());
        //FourBind
    }

    private async void btnFourBind_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FourBind());
        //
    }

    private async   void btnFiveBind_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FiveBind());
        //SixBind
    }

    //

    private async void btnMVVM_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerFindView());
        //
    }
    private async void btnSixBind_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SixBind());
        //
    }
}

