using MediaServerFrontEnd.JsonObjects;
using MediaServerFrontEnd.Messages;
using MediaServerFrontEnd.ViewModels;
using MemBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebSocket4Net;

namespace MediaServerFrontEnd.Services
{
    public class ClientConnectorService
    {
        IBus _bus;
        WebSocket websocket;

        public ClientConnectorService(IBus bus)
        {
            string address = "ws://192.168.1.21:8080/player";
            websocket = new WebSocket(address);

            websocket.Opened += websocket_Opened;
            websocket.Error += websocket_Error;
            websocket.Closed += websocket_Closed;
            websocket.MessageReceived += websocket_MessageReceived;

            websocket.Open();

            _bus = bus;
            bus.Subscribe(this);
        }

        void websocket_Opened(object sender, EventArgs e)
        {
            var socket = (sender as WebSocket);

            //Dispatcher.Invoke(() => Messages.Items.Add("Opened socket"));
        }

        void websocket_Error(object sender, ErrorEventArgs e)
        {
            var socket = (sender as WebSocket);
        }

        void websocket_Closed(object sender, EventArgs e)
        {
            var socket = (sender as WebSocket);
        }

        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var socket = (sender as WebSocket);

            var settings = new JsonSerializerSettings()
            {
                
            };


            StatusUpdate deserializedProduct = JsonConvert.DeserializeObject<StatusUpdate>(e.Message);

            GetData(JObject.Parse(e.Message));
            
            // find way to deserialize key into object or type

            Console.WriteLine();
        }

        void GetData(JObject parent)
        {
            IList<string> keys = parent.Properties().Select(p => p.Name).ToList();

            foreach (var key in keys)
            {
                var mapped = MapToType(key, parent);

                //if(mapped != null)
                //    _bus.Publish(new MessageTest(key + Environment.NewLine + mapped.ToString()));
            }
        }

        object MapToType(string key, JObject parent)
        {
            switch (key)
            {
                case "current":
                    MediaFile mediaFile = JsonConvert.DeserializeObject<MediaFile>(parent.GetValue(key).ToString());
                    //_bus.Publish(mediaFile);
                    return mediaFile;

                case "library":
                    List<MediaFile> library = JsonConvert.DeserializeObject<List<MediaFile>>(parent.GetValue(key).ToString());
                    _bus.Publish(library);
                    return library;

                case "playing":

                    bool playing = parent.GetValue(key).ToObject<bool>();
                    //_bus.Publish(new MessageTest(key + Environment.NewLine + playing.ToString()));
                    return playing;

                case "queue":
                    List<MediaFile> queue = JsonConvert.DeserializeObject<List<MediaFile>>(parent.GetValue(key).ToString());
                    _bus.Publish(queue);
                    return queue;

                default:
                    MessageBox.Show("Unknown Key: " + key);
                    return parent.GetValue(key);
                    break;
            }
            return null;
        }

        public void Handle(SendJsonMessage message)
        {
            if (websocket.State != WebSocketState.Open)
                return;

            websocket.Send(message.Json);
        }
    }
}
