using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMDbLib.Objects.TvShows;
using Watch_Show_TV.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Watch_Show_TV.Pages.Sections
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ShowInfo : Page
    {

        public ShowTv theShow;
        public ShowInfo()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                Title.Text = $"Hi, {e.Parameter.ToString()}";
            }
            else
            {
                theShow = (ShowTv)e.Parameter;
                Title.Text = theShow.getName();
                Poster.Source = theShow.getPosterImage();
                Summary.Text = theShow.getSummary();
                Summary.TextWrapping = TextWrapping.Wrap;                
                NextEpisodeDate.Text = theShow.LastAirDate();
                
                //add button for agregate or remove to favorite
                btnWatched.Content = this.checkBtnWatched();

            }
            base.OnNavigatedTo(e);
        }

        private string checkBtnWatched()
        {
            if (DB.isShowFavorite(theShow.getShowId()))
            {
                return "Eliminar serie";
            }

            return "Añadir serie";
        }

        private void btnWatched_Click(object sender, RoutedEventArgs e)
        {
            if (!DB.isShowFavorite(theShow.getShowId())) {
                DB.AddShowToFavorite(theShow.getShowId());
                btnWatched.Content = "Eliminar serie";
            } else {
                DB.RemoveShowToFavorite(theShow.getShowId());
                btnWatched.Content = "Añadir serie";
            }
                
        }
    }
}
