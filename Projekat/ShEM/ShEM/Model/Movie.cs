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
    public class Movie: Article, INotifyPropertyChanged
    {
        [DataMember]
        public string _duration;
        [DataMember]
        public string _synopsys;
        [DataMember]
        public string _director;

        public Movie()
        {

        }

        public event PropertyChangedEventHandler propertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                notifyMeWhenPropertyChanged("duration");
            }
        }

        public string synopsys
        {
            get { return _synopsys; }
            set
            {
                _synopsys = value;
                notifyMeWhenPropertyChanged("synopsys");
            }
        }

        public string director
        {
            get { return _director; }
            set
            {
                _director = value;
                notifyMeWhenPropertyChanged("director");
            }
        }

        public byte[] Image { get; internal set; }
    }
}
