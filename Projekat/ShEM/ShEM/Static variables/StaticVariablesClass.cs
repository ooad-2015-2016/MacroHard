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
        private static string ipAddress = "192.168.0.106:";
        private static string movieAPI= "http://www.omdbapi.com/?t=";
        private static string movieAPIAdditions = "&y=&plot=short&r=json";
        private string _username;
        private int _userID;
        private List<Collection> _collections;
        private string _password;
        private string _email;
        private int _numberOfCollections;
        private byte[] _profilePic;

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
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
