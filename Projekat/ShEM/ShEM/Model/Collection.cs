using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class Collection
    {
        public int _collectionID;
        public string _name;
        public int _userID;
        public bool _status;


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



    }
}
