using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class Song: Article, INotifyPropertyChanged
    {
        public string _performer;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string preformer
        {
            get { return _performer; }
            set
            {
                _performer = value;
                notifyMeWhenPropertyChanged("performer");
            }
        }
    }
}
