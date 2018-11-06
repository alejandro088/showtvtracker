using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;
using Watch_Show_TV.Class;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Watch_Show_TV.Pages.Sections
{
    public class SeasonTvItem : StackPanel
    {
        private int numSeason;
        private ShowTv theShow;
        private List<TvSeasonEpisode> episodes;

        public SeasonTvItem(int numSeason, ShowTv newShow)
        {
            this.numSeason = numSeason;
            this.theShow = newShow;

            CheckBox checkSeasonWatched = new CheckBox();
            checkSeasonWatched.Name = "season" + this.numSeason;
            checkSeasonWatched.Click += checkSeasonWatched_click;
            checkSeasonWatched.Content = "Temporada " + this.numSeason;
            checkSeasonWatched.FontSize = 24;
            checkSeasonWatched.FontWeight = FontWeights.Bold;

            this.Children.Add(checkSeasonWatched);

            episodes = theShow.getEpisodesListOfSeason(this.numSeason);

            foreach (TvSeasonEpisode episode in episodes)
            {
                if (!(bool)DB.isEpisodeWatched(episode.Id))
                {
                    EpisodeTvItem itemEpisode = new EpisodeTvItem(episode, theShow);
                    itemEpisode.Width = this.Width;

                    Thickness marginTop = new Thickness();
                    marginTop.Top = 10;
                    itemEpisode.Margin = marginTop;

                    this.Children.Add(itemEpisode);
                }
            }
        }

        private void checkSeasonWatched_click(object sender, RoutedEventArgs e)
        {
            //code here
        }
    }
}
