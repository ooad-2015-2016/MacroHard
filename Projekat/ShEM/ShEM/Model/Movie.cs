using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class Movie: Article, INotifyPropertyChanged
    {
        public int _duration;
        public string _synopsys;
        public string _director;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int duration
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
    }
}
