using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
using Windows.UI.Xaml.Media.Imaging;

namespace Watch_Show_TV.Class
{
    public class ShowTv
    {
        public TvShow showInfo;
        public BitmapImage PosterImage { get; set; }
        public String AirsDate { get; set; }
        public String Name { get; set; }

        public ShowTv(int newShowId)
        {
            showInfo = TMDB.client.GetTvShowAsync(newShowId).Result;
            this.PosterImage = getPosterImage();
            try { 
                this.AirsDate = showInfo.FirstAirDate.Value.ToShortDateString();
            } catch(InvalidOperationException e)
            {
                this.AirsDate = "";
            }
            this.Name = showInfo.Name;

        }

        public String getName()
        {
            return showInfo.Name;            
        }

        public List<Cast> getCast()
        {
            try
            {
                return showInfo.Credits.Cast;
            } catch (NullReferenceException e)
            {
                return new List<Cast>();
            }          
                        
        }

        public BitmapImage getPosterImage()
        {
            Uri uri = new Uri("https://image.tmdb.org/t/p/original" + showInfo.PosterPath);

            BitmapImage image = new BitmapImage(uri);

            image.DecodePixelHeight = 400;

            return image;
        }

        public String LastAirDate()
        {
            DateTime date = (DateTime)showInfo.LastAirDate;
            return date.ToShortDateString();
        }

        public string getSummary()
        {
            return showInfo.Overview;
        }

        public string getHomepage()
        {
            return showInfo.Homepage;
        }

        public int getShowId()
        {
            return showInfo.Id;
        }

        public List<TvSeasonEpisode> getEpisodesListOfSeason(int seasonNumber)
        {
            TvSeason season = TMDB.client.GetTvSeasonAsync(showInfo.Id, seasonNumber).Result;
            List<TvSeasonEpisode> episodes = season.Episodes;

            return episodes;
        }

        public int getSeasonsNumber()
        {
            return showInfo.NumberOfSeasons;
        }

        public double getRating()
        {
            return (showInfo.VoteAverage / 2);
        }

        public string getImdbId()
        {
            return showInfo.ExternalIds.ImdbId;
        }

        public string getTvdbId()
        {
            return showInfo.ExternalIds.TvdbId;
        }

        public string getFreebaseId()
        {
            return showInfo.ExternalIds.FreebaseId;
        }


    }
}
