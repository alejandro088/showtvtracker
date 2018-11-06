using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.People;
using Windows.UI.Xaml.Media.Imaging;

namespace Watch_Show_TV.Class
{
    public class Actor
    {
        public Person person;
        public BitmapImage Photo { get; set; }
        public String Name { get; set; }        

        public Actor(int newActorId)
        {
            person = TMDB.client.GetPersonAsync(newActorId).Result;
            this.Photo = getProfilePhoto();
            this.Name = person.Name;
        }

        private BitmapImage getProfilePhoto()
        {
            Uri uri = new Uri("https://image.tmdb.org/t/p/original" + person.ProfilePath);

            BitmapImage image = new BitmapImage(uri);

            image.DecodePixelHeight = 400;

            return image;
        }
    }
}
