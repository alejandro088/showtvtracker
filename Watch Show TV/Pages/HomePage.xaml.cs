using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
using Watch_Show_TV.Class;
using Watch_Show_TV.Pages.Sections;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Watch_Show_TV.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        List<ShowTv> lResult;
        public HomePage()
        {
            this.InitializeComponent();

            SearchContainer<SearchTv> topResults = TMDB.client.GetTvShowTopRatedAsync().Result;
            List<ShowTv> topResult = new List<ShowTv>();
            foreach (SearchTv result in topResults.Results)
            {
                topResult.Add(new ShowTv(result.Id));
            }

            TVPopular.ItemsSource = topResult;          

        }

        private void txtSearch_KeyUp(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
                btnSearch.IsEnabled = false;
            else
                btnSearch.IsEnabled = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;

            SearchContainer<SearchTv> results = TMDB.client.SearchTvShowAsync(txtSearch.Text).Result;

            lResult = new List<ShowTv>();
            foreach (SearchTv result in results.Results) { 
                
                lResult.Add(new ShowTv(result.Id));
            }

            Output.ItemsSource = lResult;

            Progress.IsActive = false;

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender.Equals(TVPopular))
                this.Frame.Navigate(typeof(ShowInfo), (ShowTv)TVPopular.SelectedItem);
            else if (sender.Equals(Output))
                this.Frame.Navigate(typeof(ShowInfo), (ShowTv)Output.SelectedItem);
        }
    }
}
