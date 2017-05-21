using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using GPS;
using Microsoft.Phone.Tasks;
using Coding4Fun.Phone.Controls.Data;

namespace UsingBingMaps
{
    public partial class HelpPage : PhoneApplicationPage
    {
        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();
        MarketplaceReviewTask _marketplaceReview = new MarketplaceReviewTask();
        MarketplaceSearchTask _marketplaceSearch = new MarketplaceSearchTask();
        EmailComposeTask _emailComposeTask = new EmailComposeTask();

        public HelpPage()
        {
            InitializeComponent();
            #region Paid version Check
            if (App.isPaidVersion == true)
            {
                // disables ads
                adControl.Visibility = System.Windows.Visibility.Collapsed;
                //adControl.IsAutoRefreshEnabled = false;
                adControl.IsEnabled = false;
                adControl.IsAutoCollapseEnabled = false;
                svHelp.Height = 605;
                svHelp.Margin = new Thickness(0, 0, 0, 549);
            }
            else
            {
                // enable ads
                adControl.Visibility = System.Windows.Visibility.Visible;
                //adControl.IsAutoRefreshEnabled = true;
                adControl.IsEnabled = true;
                adControl.IsAutoCollapseEnabled = false;
            }
            #endregion
            txtAppName.Text = PhoneHelper.GetAppAttribute("Title") + " by " + PhoneHelper.GetAppAttribute("Author");
            txtVersion.Text = "version " + PhoneHelper.GetAppAttribute("Version");
            txtDescription.Text = PhoneHelper.GetAppAttribute("Description");
        }

        private void btnBuyApp_Click(object sender, RoutedEventArgs e)
        {
            _marketPlaceDetailTask.Show();
        }


        private void btnMarketplace_Click(object sender, RoutedEventArgs e)
        {
            _marketplaceSearch.SearchTerms = "PNGC WP7";
            _marketplaceSearch.Show();
        }

        private void btnReview_Click(object sender, RoutedEventArgs e)
        {
            _marketplaceReview.Show();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            _emailComposeTask.To = "pngc.wp7@hotmail.com";
            _emailComposeTask.Subject = "todo GPS Feedback";
            _emailComposeTask.Show();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            #region Trial Mode Check
            //if (App.IsTrial == true)
            //{
            //    // enable ads
            //    //adControl.Visibility = System.Windows.Visibility.Visible;
            //    ////adControl.IsAutoRefreshEnabled = true;
            //    //adControl.IsEnabled = true;
            //    //adControl.IsAutoCollapseEnabled = false;
            //    btnBuyApp.IsEnabled = true;
            //    btnBuyApp.Visibility = System.Windows.Visibility.Visible;
            //}
            //else
            //{
            //    // disables ads
            //    //adControl.Visibility = System.Windows.Visibility.Collapsed;
            //    ////adControl.IsAutoRefreshEnabled = false;
            //    //adControl.IsEnabled = false;
            //    //adControl.IsAutoCollapseEnabled = false;
            //    btnBuyApp.IsEnabled = false;
            //    btnBuyApp.Visibility = System.Windows.Visibility.Collapsed;
            //}
            #endregion
        }


    }
}