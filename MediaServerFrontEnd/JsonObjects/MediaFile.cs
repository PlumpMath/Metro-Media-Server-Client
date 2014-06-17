using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServerFrontEnd.JsonObjects
{
    public class MediaFile
    {
        public string Artist { get; set; }

        public string Album { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Genre { get; set; }

        public string Duration { get; set; }
    }

    public class StatusUpdate
    {
        public MediaFile current { get; set; }

        public bool playing { get; set; }

        public List<string> playlist { get; set; }

        public StatusUpdate()
        {
            playlist = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(string.Format("Current: {0}, ", current));
            sb.Append(string.Format("Playing: {0}, ", playing ? "Yes" : "No"));
            sb.Append("Playlists: " + playlist.Count);

            return sb.ToString();
        }
    }

    class SomeMessage1
    {
        // Need a string that specifies that I can map these values to a "SomeMessage1" object

        int duration;

        int name;
    }

    public class Pause
    {
    }
}
