using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class User: INotifyPropertyChanged
    {
        public int _userID;
        public string _username;
        public List<Collection> _collections;
        public string _password;
        public string _email;
        public int _numberOfCollections;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int userID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                notifyMeWhenPropertyChanged("userID");
            }
        }

        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                notifyMeWhenPropertyChanged("username");
            }
        }

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                notifyMeWhenPropertyChanged("email");
            }
        }

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                notifyMeWhenPropertyChanged("password");
            }
        }

        public List<Collection> collections
        {
            get { return _collections; }
            set
            {
                _collections = value;
                notifyMeWhenPropertyChanged("collections");
            }
        }

        public int numberOfCollections
        {
            get { return _numberOfCollections; }
            set
            {
                _numberOfCollections = value;
                notifyMeWhenPropertyChanged("numberOfCollections");
            }
        }
    }
}
