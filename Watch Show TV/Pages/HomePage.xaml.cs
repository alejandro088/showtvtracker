using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
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
        public HomePage()
        {
            this.InitializeComponent();

            TvShow show = MainPage.client.GetLatestTvShowAsync().Result;

            TvShow.Text = show.Name;

            Uri uri = new Uri("https://image.tmdb.org/t/p/original" + show.PosterPath);

            BitmapImage image = new BitmapImage(uri);

            Image imageShow = new Image();
            imageShow.Source = image;
            imageShow.Height = 400;

            sPanel1.Children.Add(imageShow);
            

            TextBlock txtUri = new TextBlock();
            txtUri.Text = show.PosterPath;

            sPanel1.Children.Add(txtUri);
        }
    }
}
