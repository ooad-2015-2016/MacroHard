﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ShEM.Model
{
    [DataContract]
    public class Song : Article
    {
        [DataMember]
        public string _performer;
        [DataMember]
        public string _preview;


        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyMeWhenPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string performer
        {
            get { return _performer; }
            set
            {
                _performer = value;
                notifyMeWhenPropertyChanged("performer");
            }
        }
        public string preview
        {
            get { return _preview; }
            set
            {
                _preview = value;
                notifyMeWhenPropertyChanged("preview");
            }
        }
    }
}
