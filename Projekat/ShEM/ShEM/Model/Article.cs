using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public abstract class Article: INotifyPropertyChanged
    {
        public int _articleID;
        public string _articleName;
        public string _genre;
        public byte[] _image;
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
