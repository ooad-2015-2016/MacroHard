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
    public class Book : Article
    {
        [DataMember]
        public string _author;
        [DataMember]
        public string _publisher;
        [DataMember]
        public string _synopsys;

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
        public string synopsys
        {
            get { return _synopsys; }
            set
            {
                _synopsys = value;
                notifyMeWhenPropertyChanged("synopsys");
            }
        }
    }
}
