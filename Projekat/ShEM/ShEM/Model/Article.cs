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
    public abstract class Article : INotifyPropertyChanged
    {
        [DataMember]
        public int _articleID;
        [DataMember]
        public string _articleName;
        [DataMember]
        public byte[] _image;


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

        public byte[] image
        {
            get { return _image; }
            set
            {
                this._image = value;
                notifyMeWhenPropertyChanged("image");
            }
        }


    }
}
