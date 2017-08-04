﻿using AMP.ViewModels;
using AMP.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AMP.Views
{
    public class NavAwarePage : Page
    {

        public NavAwarePage() : base()
        {
            this.Loaded += NavAwarePage_Loaded;
        }

        private void NavAwarePage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Debug.WriteLine("loaded");
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var navigableViewModel = this.DataContext as INavAware;
            if (navigableViewModel != null)
                navigableViewModel.Activate(e.Parameter);

            var asyncViewModel = this.DataContext as IAsyncInitialization;
            if (asyncViewModel != null)
                await asyncViewModel.Initialization;
        }

        

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var navigableViewModel = this.DataContext as INavAware;
            if (navigableViewModel != null)
                navigableViewModel.Deactivate(e.Parameter);
        }

    }
}
