using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class Book: Article
    {
        public string _author;
        public string _publisher;

        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string publisher
        {
            get { return _author; }
            set
            {
                _publisher = value;
                notifyMeWhenPropertyChanged("publisher");
            }
        }

        public string author
        {
            get { return _author; }
            set
            {
                _author = value;
                notifyMeWhenPropertyChanged("author");
            }
        }
    }
}
