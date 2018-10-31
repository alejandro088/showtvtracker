using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.AirsDate = showInfo.FirstAirDate.ToString();
            this.Name = showInfo.Name;

        }

        public String getName()
        {
            return showInfo.Name;
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
            return date.Date.ToString();
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
    }
}
