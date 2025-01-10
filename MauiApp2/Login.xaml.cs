using MauiApp2.Model;
using System;
namespace MauiApp2;

public partial class Login : ContentPage
{
	public Login()
    {
        InitializeComponent();
    }

    private void KayitLoginEkraniGoster(object sender, EventArgs e)
    {
        if (kayitEkran.IsVisible)
        {
            kayitEkran.IsVisible = false;
            loginEkran.IsVisible = true;
            lblTitle.Text = "Giri� Yap�n�z";
        }
        else
        {
            loginEkran.IsVisible = false;
            kayitEkran.IsVisible = true;
            lblTitle.Text = "Kay�t Olunuz";
        }
    }

        private async void RegisterClicked(object sender, EventArgs e)
    {
        var user = await FireBaseServices.Register(txtName.Text, txtREmail.Text, txtRPassword.Text);
        if (user != null)
        {
            await DisplayAlert("Ba�ar�l�", "Kay�t ba�ar�l�", "OK");
            KayitLoginEkraniGoster(sender, e);
        }
        else
        {
            await DisplayAlert("Hata", "Kay�t ba�ar�s�z", "OK");
        }
    }

    private async void LoginInClicked(object sender, EventArgs e)
    {
        var user = await FireBaseServices.Login(txtEmail.Text, txtPassword.Text);
        if (user != null)
        {
            await DisplayAlert($"Ho�geldin {user.Info.DisplayName}", "Giri� ba�ar�l�", "OK");
            ((App)Application.Current).NavigateToMainPage();
        }
        else
        {
            await DisplayAlert("Hata", "Kullan�c� ad� veya �ifre hatal�", "OK");
        }
    }

}
