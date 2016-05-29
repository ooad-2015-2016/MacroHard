using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ShEM.Model
{
    [DataContract]
    public class Collection
    {
        [DataMember]
        public int _collectionID;
        [DataMember]
        public string _name;
        [DataMember]
        public int _userID;
        [DataMember]
        public bool _status;
        [DataMember]
        List<Book> _books;
        [DataMember]
        List<Movie> _movies;
        [DataMember]
        List<Song> _songs;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int collectionID
        {
            get { return _collectionID; }
            set
            {
                _collectionID = value;
                notifyMeWhenPropertyChanged("collectionID");
            }
        }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                notifyMeWhenPropertyChanged("name");
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

        public List<Book> books
        {
            get { return _books; }
            set
            {
                _books = value;
                notifyMeWhenPropertyChanged("books");
            }
        }

        public List<Movie> movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                notifyMeWhenPropertyChanged("movies");
            }
        }

        public List<Song> songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                notifyMeWhenPropertyChanged("songs");
            }
        }

    }
}
