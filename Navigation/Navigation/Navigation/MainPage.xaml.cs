using System;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Navigation {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async void StartNavegation_Clicked(object sender, EventArgs e) {

            if (Device.RuntimePlatform == Device.iOS) {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync($"http://maps.apple.com/?daddr={GoingToTxt.Text}&saddr={CommingFromTxt.Text}");
            } else if (Device.RuntimePlatform == Device.Android) {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync($"http://maps.google.com/?daddr={GoingToTxt.Text}&saddr={CommingFromTxt.Text}");
            } else if (Device.RuntimePlatform == Device.UWP) {
                await Launcher.OpenAsync($"bingmaps:?rtp=adr.{CommingFromTxt.Text}~adr.{GoingToTxt.Text}");
            }
        }

        private void CommingFromTxt_TextChanged(object sender, TextChangedEventArgs e) {

            StartNavegation.IsEnabled = IsButtonEnabled();
        }

        private bool IsButtonEnabled() {

            if (string.IsNullOrEmpty(CommingFromTxt.Text) ||
                string.IsNullOrEmpty(GoingToTxt.Text)) {
                return false;
            } else {
                return true;
            }
        }
    }
}
