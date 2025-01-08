using ChatApplication.Core;
using ChatApplication.Model;
using ChatApplication.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        
        public RelayCommand ConnectToServerCommand { get; set; }
        public RelayCommand SendMessageToServerCommand { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }

        public event Action UsersChanged;
        public event Action MessagesChanged;
        private Server _server;
        public MainViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            Messages = new ObservableCollection<string>();
            _server = new Server(); 
            _server.connectedEvent += UserConnected;
            _server.messageReceivedEvent += MessageReceived;
            _server.userDisconnectedEvent += RemoveUser;
            Users.CollectionChanged += OnUsersChanged;
            Messages.CollectionChanged += OnMessagesChanged;
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(Username),o => !string.IsNullOrEmpty(Username));
            SendMessageToServerCommand = new RelayCommand(o => _server.SendMessageToServer(Message), o => !string.IsNullOrEmpty(Message));
        }
        private void UserConnected()
        {
            var user = new UserModel
            {
                Username = _server.packetReader.ReadMessage(),
                UID = _server.packetReader.ReadMessage()


            };

            if(!Users.Any(x => x.UID == user.UID))
            {


                Users.Add(user);
                Console.WriteLine("User addded");
                Console.WriteLine(Users.Count);
            }
        }
        private void MessageReceived()
        {
            var message = _server.packetReader.ReadMessage();
            Messages.Add(message);
            Console.WriteLine("Message Received");
            Console.WriteLine(message);
            
            

        }
        private void RemoveUser()
        {
            var UID = _server.packetReader.ReadMessage();
            var user = Users.Where(x => x.UID == UID).FirstOrDefault();
            Users.Remove(user);
        }
        private void OnUsersChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UsersChanged?.Invoke();
        }

        private void OnMessagesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessagesChanged?.Invoke();
        }

    }
}   
