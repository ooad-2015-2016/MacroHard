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
    public class Movie : Article
    {
        [DataMember]
        public string _duration;
        [DataMember]
        public string _synopsys;
        [DataMember]
        public string _director;
        [DataMember]
        public string _yearOfRelease;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
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
        public string yearOfRelease
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
