using App10.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace App10
{
    public class MainViewModel : ObservableObject
    {
        private int tabSelectedIndex;

        public int TabSelectedIndex
        {
            get { return tabSelectedIndex; }
            set { SetProperty(ref tabSelectedIndex, value); }
        }

        private Page appMain;

        public Page Appmain
        {
            get { return appMain; }
            set { SetProperty(ref appMain, value); }
        }

        public ICommand TabSelectionCommand { get; }

        public MainViewModel()
        {
            TabSelectionCommand = new Command(TabSelectionChanged);
            MessagingCenter.Instance.Subscribe<HomeViewModel, int>(this, "tab", (s, e) => {
                TabSelectedIndex = e;
            });
        }

        private void TabSelectionChanged(object arg)
        {
            HomeView homeView = Appmain.FindByName<HomeView>("homeView");

            if (homeView != null)
            {
                if (!(homeView.BindingContext is HomeViewModel))
                {
                    homeView.BindingContext = new HomeViewModel();
                }
            }
        }
    }
}
