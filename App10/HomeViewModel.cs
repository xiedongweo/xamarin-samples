using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace App10
{
    public class HomeViewModel : ObservableObject
    {
        public ICommand GoDeviceCommand { get; }

        public HomeViewModel()
        {
            GoDeviceCommand = new Command(GoDevice);
        }

        private void GoDevice()
        {
            MessagingCenter.Instance.Send(this, "tab", 3);
        }
    }
}
