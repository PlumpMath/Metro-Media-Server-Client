using MediaServerFrontEnd.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServerFrontEnd.ViewModels.Wrappers
{
    /// <summary>
    /// Holds all of the metadata associated with a song.
    /// Would be good to convert this to Caliburn.Micro 2.0 to get the better
    /// NotifyOfPropertyChange setter/notify...
    /// </summary>
    public class MediaFileWrapper : BaseWrapper<MediaFile>
    {
        public string Artist
        {
            get { return Model.Artist; }
            set 
            { 
                Model.Artist = value;
                NotifyOfPropertyChange(() => Artist);
            }
        }

        public string Album
        {
            get { return Model.Album; }
            set
            {
                Model.Album = value;
                NotifyOfPropertyChange(() => Album);
            }
        }

        public string Title
        {
            get { return Model.Title; }
            set
            {
                Model.Title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public string Path
        {
            get { return Model.Path; }
            set
            {
                Model.Artist = value;
                NotifyOfPropertyChange(() => Path);
            }
        }

        public string Genre
        {
            get { return Model.Genre; }
            set
            {
                Model.Genre = value;
                NotifyOfPropertyChange(() => Genre);
            }
        }

        public string Duration
        {
            get { return Model.Duration; }
            set
            {
                Model.Duration = value;
                NotifyOfPropertyChange(() => Duration);
            }
        }

        public MediaFileWrapper(MediaFile media)
            : base(media)
        {

        }
    }
}
