using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppStudio.Common;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
#if WINDOWS_APP
using Electrorithm.AppFlyouts;
#endif
using Electrorithm.ViewModels;

namespace Electrorithm.Commands
{
    public class PlatformCommands
    {

        public static ICommand About
        {
            get
            {
                return new RelayCommand(() =>
                {
#if WINDOWS_APP
                    var flyout = new AboutFlyout();
                    flyout.Show();
#endif
#if WINDOWS_PHONE_APP
                    NavigationService.NavigateToPage(typeof(AboutThisAppPage));
#endif

                });
            }
        }

        public static ICommand Privacy
        {
            get
            {
                return new RelayCommand(() =>
                {
#if WINDOWS_APP
                    var flyout = new PrivacyFlyout();
                    flyout.Show();
#endif
#if WINDOWS_PHONE_APP
                    PrivacyViewModel vm = new PrivacyViewModel();
                    NavigationService.NavigateTo(vm.Url).FireAndForget();
#endif

                });
            }
        }
    }
}
