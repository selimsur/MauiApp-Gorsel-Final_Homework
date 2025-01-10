namespace MauiApp2
{
    public partial class Ayarlar : ContentPage
    {
        public Ayarlar()
        {
            InitializeComponent();

            Application.Current.UserAppTheme = AppTheme.Dark;

            UpdateLabel();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                if (e.Value)
                    Application.Current.UserAppTheme = AppTheme.Light;
                else
                    Application.Current.UserAppTheme = AppTheme.Dark;

                UpdateLabel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }

        private void UpdateLabel()
        {
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                switchControlLabel.Text = "Buton uygulamayý açýk tema moduna alýr";
                switchControlLabel.Style = (Style)Resources["DarkLabelStyle"];
            }
            else
            {
                switchControlLabel.Text = "Buton uygulamayý koyu tema moduna alýr";
                switchControlLabel.Style = (Style)Resources["DefaultLabelStyle"];
            }
        }
    }
}
