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
    public abstract class Article: INotifyPropertyChanged
    {
        [DataMember]
        public int _articleID;
        [DataMember]
        public string _articleName;
        [DataMember]
        public string _genre;
        [DataMember]
        public byte[] _image;
        [DataMember]
        public int _yearOfRelease;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int articleID
        {
            get { return _articleID; }
            set
            {
                this._articleID = value;
                notifyMeWhenPropertyChanged("articleID");
            }   
        }

        public string articleName
        {
            get { return _articleName; }
            set
            {
                this._articleName = value;
                notifyMeWhenPropertyChanged("articleName");
            }
        }

        public string genre
        {
            get { return _genre; }
            set
            {
                this._genre = value;
                notifyMeWhenPropertyChanged("genre");
            }
        }

        public byte[] image
        {
            get { return _image; }
            set
            {
                this._image = value;
                notifyMeWhenPropertyChanged("image");
            }
        }

        public int yearOfRelease
        {
            get { return _yearOfRelease; }
            set
            {
                this._yearOfRelease = value;
                notifyMeWhenPropertyChanged("yearOfRelease");
            }
        }
    }
}
