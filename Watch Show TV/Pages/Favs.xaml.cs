using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Watch_Show_TV.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Favs : Page
    {
        public Favs()
        {
            this.InitializeComponent();

            this.loadListShowFavs();
        }

        public void loadListShowFavs()
        {
            List<int> results = DB.GetShowFavorites();
            List<ShowTv> lResult = new List<ShowTv>();
            foreach (int result in results)
            {
                lResult.Add(new ShowTv(result));
            }

            Output.ItemsSource = lResult;
        }

        private void Output_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(ShowInfo), (ShowTv)Output.SelectedItem);

        }
    }
}
