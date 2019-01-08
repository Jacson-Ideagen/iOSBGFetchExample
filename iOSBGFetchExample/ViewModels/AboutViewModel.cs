using System.Windows.Input;
using Xamarin.Essentials;

namespace iOSBGFetchExample
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Browser.OpenAsync("https://xamarin.com/platform"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
