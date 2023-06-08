using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public IList<FrameRasp> frameRasps { get; set; }



        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            frameRasps = new List<FrameRasp>();

            frameRasps.Add(new FrameRasp()
            {
                Data = "02.02.03",
                ButtonSourse = "Stub.png",
                Raspisanie = "TestRaspisanie.jpg"
            });

            frameRasps.Add(new FrameRasp()
            {
                Data = "32.02.03",
                ButtonSourse = "Stub.png",
                Raspisanie = "TestRaspisanie.jpg"
            });
            frameRasps.Add(new FrameRasp()
            {
                Data = "42.02.03",
                ButtonSourse = "Stub.png",
                Raspisanie = "TestRaspisanie.jpg"
            });
            frameRasps.Add(new FrameRasp()
            {
                Data = "52.02.03",
                ButtonSourse = "Stub.png",
                Raspisanie = "TestRaspisanie.jpg"
            });
            BindingContext = this;

            base.OnAppearing();
        }

        async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FrameRasp frameRasp = e.CurrentSelection[0] as FrameRasp;
            await DisplayAlert(frameRasp.Data, frameRasp.Raspisanie, "OK");
        }

        private async void Contact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contacts(), false);
        }

        private void Schedule_Clicked(object sender, EventArgs e)
        {

        }

        private void Bell_Clicked(object sender, EventArgs e)
        {

        }
    }
}
