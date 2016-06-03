using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;

namespace ShEM.BazaPodataka.Static_variables
{
    public class StaticVariablesClass
    {
        private static int port = 3000;
        private static string ipAddress = "192.168.1.6:";
        private static string movieAPI= "http://www.omdbapi.com/?t=";
        private static string movieAPIAdditions = "&y=&plot=short&r=json";
        private static string _username;
        private static int _userID;
        private static List<Collection> _collections;
        private static string _email;
        private static int _numberOfCollections;
        private static byte[] _profilePic;
        private string songAPI = "https://api.spotify.com/v1/search?q=";
        private string songAPIAdditions= "&type=track&limit=1";
        private string bookAPI= "https://www.googleapis.com/books/v1/volumes?q=";
        private string bookAPIAdditions = "&maxResults=1";

        public string BookAPIAdditions
        {
            get { return bookAPIAdditions; }
            set { bookAPIAdditions = value; }
        }


        public string BookAPI
        {
            get { return bookAPI; }
            set { bookAPI = value; }
        }


        public string SongAPIAdditions
        {
            get { return songAPIAdditions; }
            set { songAPIAdditions = value; }
        }


        public string SongAPI
        {
            get { return songAPI; }
            set { songAPI = value; }
        }


        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }



        public List<Collection> collections
        {
            get { return _collections; }
            set
            {
                _collections = value;
            }
        }

        public int numberOfCollections
        {
            get { return _numberOfCollections; }
            set
            {
                _numberOfCollections = value;
            }
        }

        public byte[] profilePic
        {
            get { return _profilePic; }
            set
            {
                _profilePic = value;
            }
        }
        public int userID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }


        public string MovieAPI
        {
            get { return movieAPI; }
        }

        public string MovieAPIAdditions
        {
            get { return movieAPIAdditions; }
         
        }


        public string getIP
        {
            get { return ipAddress; }
        } 

        public int getPort
        {
            get
            {
                return port;
            }
        }
    }
}
