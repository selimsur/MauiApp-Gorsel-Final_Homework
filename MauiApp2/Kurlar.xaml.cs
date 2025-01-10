using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class Kurlar : ContentPage
    {
        private static Kurlar instance;

        public Kurlar()
        {
            InitializeComponent();
        }

        public static Kurlar Page
        {
            get
            {
                if (instance == null)
                    instance = new Kurlar();
                return instance;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Load();
        }

        private string CalculateFark(string alis, string satis)
        {
            if (decimal.TryParse(satis, out decimal satisValue) && decimal.TryParse(alis, out decimal alisValue))
            {
                decimal fark = satisValue - alisValue;
                return fark.ToString("0.00");
            }
            return "0.00";
        }

        private string GetImage(string de�i�im)
        {
            if (decimal.TryParse(de�i�im.Replace("%", "").Replace(",", "."), out decimal de�i�imValue))
            {
                if (de�i�imValue < 0)
                    return "asagi.png";
                if (de�i�imValue > 0)
                    return "yukari.png";
                return "sabit.png";
            }
            return "";
        }


        AltinDoviz kurlar;

        async Task Load()
        {
            try
            {
                string jsondata = await Dovizler.GetAltinDovizGuncelKurlar();
                kurlar = JsonSerializer.Deserialize<AltinDoviz>(jsondata, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                DovizListe.ItemsSource = new List<DovizK>()
                {
                    new DovizK()
                    {
                        Dname = "Dolar",
                        Al�� = kurlar.USD.Al��,
                        Sat�� = kurlar.USD.Sat��,
                        De�i�im = kurlar.USD.De�i�im,
                        Yon = GetImage(kurlar.USD.De�i�im)
                    },
                    new DovizK()
                    {
                        Dname = "Euro",
                        Al�� = kurlar.EUR.Al��,
                        Sat�� = kurlar.EUR.Sat��,
                        De�i�im = kurlar.EUR.De�i�im,
                        Yon = GetImage(kurlar.EUR.De�i�im)
                    },

                    new DovizK()
                    {
                        Dname = "GBP",
                        Al�� = kurlar.GBP.Al��,
                        Sat�� = kurlar.GBP.Sat��,
                        De�i�im = kurlar.GBP.De�i�im,
                        Yon = GetImage(kurlar.GBP.De�i�im)
                    },

                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Load();
        }

        public class DovizK
        {
            public string Dname { get; set; }
            public string Al�� { get; set; }
            public string Sat�� { get; set; }
            public string De�i�im { get; set; }
            public string Yon { get; set; }
        }
    }

    public class AltinDoviz
    {
        public USD USD { get; set; }
        public EUR EUR { get; set; }
        public GBP GBP { get; set; }
    }

    public class EUR { public string Sat�� { get; set; } public string Al�� { get; set; } public string De�i�im { get; set; } }
    public class GBP { public string Sat�� { get; set; } public string Al�� { get; set; } public string De�i�im { get; set; } }
    public class USD { public string Sat�� { get; set; } public string Al�� { get; set; } public string De�i�im { get; set; } }
}
