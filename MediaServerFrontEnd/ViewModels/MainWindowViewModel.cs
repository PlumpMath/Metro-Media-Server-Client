using Caliburn.Micro;
using MediaServerFrontEnd.JsonObjects;
using MediaServerFrontEnd.Messages;
using MediaServerFrontEnd.Services;
using MediaServerFrontEnd.ViewModels.Wrappers;
using MemBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServerFrontEnd.ViewModels
{
    public class MainWindowViewModel : Screen
    {
        IBus _bus;
        ClientConnectorService connection;

        private IObservableCollection<MediaFileWrapper> _messages;
        public IObservableCollection<MediaFileWrapper> Messages
        {
            get { return _messages; }
            set 
            {
                NotifyOfPropertyChange(() => Messages);
                _messages = value;
            }
        }
        
        public MainWindowViewModel(IBus bus, ClientConnectorService connection)
        {
            _bus = bus;
            this.connection = connection;

            Messages = new BindableCollection<MediaFileWrapper>();

            bus.Subscribe(this);
            this.DisplayName = "Media Player";

        }

        public void TestButton()
        {
            Messages.Add(new MediaFileWrapper(new MediaFile()
                {
                    Album = "Octavarium",
                    Artist = "Dream Theater",
                    Duration = "24:17",
                    Genre = "Melodic Metal",
                    Path = "/files/dream_theater/octavarium/octavarium.mp3",
                    Title = "Octavarium"
                }));

            // Test to communicate with the back end.
            // Isn't fully fleshed out in the protocol yet.
            //Type pauseType = typeof(Pause);
            //object boxedPause = new Pause();

            //var convertDictionary = new Dictionary<string, object>();
            //convertDictionary.Add(pauseType.Name.ToLower(), JsonConvert.SerializeObject(boxedPause));
            
            //_bus.Publish(new SendJsonMessage(JsonConvert.SerializeObject(convertDictionary)));
        }

        public void Handle(MediaFile a)
        {
            Messages.Add(new MediaFileWrapper(a));
        }

        public void Handle(List<MediaFile> a)
        {
            a.ForEach(p => Messages.Add(new MediaFileWrapper(p)));
        }
    }
}
