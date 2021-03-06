﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net.Http;
using System.Runtime.Serialization;

namespace ShEM.Model
{
    [DataContract]
    public class User: INotifyPropertyChanged
    {
        [DataMember]
        public int _userID;
        [DataMember]
        public string _username;
        [DataMember]
        public List<Collection> _collections;
        [DataMember]
        public string _password;
        [DataMember]
        public string _email;
        [DataMember]
        public int _numberOfCollections;
        [DataMember]
        public byte[] _profilePic;

        public event PropertyChangedEventHandler PropertyChanged;
        public User() { }
        public User(int _userID,string _username, string _email)
        {
            this._userID = _userID;
            this._username = _username;
            this._email = _email;
         //   this._profilePic = _profilePic;
        }
        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public byte[] profilePic
        {
            get { return _profilePic; }
            set
            {
                _profilePic = value;
                notifyMeWhenPropertyChanged("profilePicture");
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
