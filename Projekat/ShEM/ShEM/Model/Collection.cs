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
        public bool _status;
        [DataMember]
        List<Article> _articles;
      

        public event PropertyChangedEventHandler PropertyChanged;

        public Collection(int _collectionID, string _name, bool _status)
        {
            this._collectionID = _collectionID;
            this._name = _name;
            this._status = _status;
            _articles = new List<Article>();
        }



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



        public List<Article> articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
                notifyMeWhenPropertyChanged("books");
            }
        }

    }
}
