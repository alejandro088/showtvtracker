using System;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
using Watch_Show_TV.Class;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Watch_Show_TV.Pages.Sections
{
    public class EpisodeTvItem : StackPanel
    {
        private TvSeasonEpisode episode;
        private ShowTv theShow;

        public EpisodeTvItem(TvSeasonEpisode episode, ShowTv newShow)
        {
            this.episode = episode;
            this.theShow = newShow;

            this.Width = 600;

            this.Orientation = Orientation.Horizontal;

            StackPanel episodeResume = new StackPanel();
            episodeResume.Width = this.Width * 0.75;

            TextBlock txtEpisodeName = new TextBlock();
            txtEpisodeName.Text = "Episode " + this.episode.EpisodeNumber + ": " + this.episode.Name;
            txtEpisodeName.FontSize = 16;
            txtEpisodeName.FontWeight = FontWeights.Bold;

            TextBlock txtEpisodeOverview = new TextBlock();
            txtEpisodeOverview.Text = this.episode.Overview;
            txtEpisodeOverview.TextWrapping = TextWrapping.Wrap;

                        

            TextBlock txtEpisodeAirDate = new TextBlock();
            try {
                txtEpisodeAirDate.Text = this.episode.AirDate.Value.ToShortDateString();
            }
            catch (Exception e)
            {
                txtEpisodeAirDate.Text = "";
            }
            episodeResume.Children.Add(txtEpisodeName);
            episodeResume.Children.Add(txtEpisodeOverview);
            episodeResume.Children.Add(txtEpisodeAirDate);

            this.Children.Add(episodeResume);

            StackPanel episodeCheckWatched = new StackPanel();
            episodeCheckWatched.Width = this.Width * 0.25;

            TextBlock txtEpisodeWatched = new TextBlock();
            txtEpisodeWatched.Text = "Watched?";

            CheckBox checkEpisodeWatched = new CheckBox();
            checkEpisodeWatched.Name = this.episode.Id.ToString();
            checkEpisodeWatched.IsChecked = DB.isEpisodeWatched(this.episode.Id);

            checkEpisodeWatched.Click += checkEpisodeWatched_click;

            episodeCheckWatched.Children.Add(txtEpisodeWatched);
            episodeCheckWatched.Children.Add(checkEpisodeWatched);
            this.Children.Add(episodeCheckWatched);

        }

        private void checkEpisodeWatched_click(object sender, RoutedEventArgs e)
        {
            if ((bool)DB.isEpisodeWatched(this.episode.Id))
                DB.removeEpisodeWatched(this.episode.Id);
            else
                DB.addEpisodeWatched(this.episode, this.theShow);
        }

        public TvSeasonEpisode getEpisode()
        {
            return this.episode;
        }
    }
}