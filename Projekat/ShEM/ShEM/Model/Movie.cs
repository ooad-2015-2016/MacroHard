using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShEM.Model
{
    public class Movie: Article
    {
        public int _duration;
        public string _synopsys;
        public string _director;

        public int duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                
            }
        }
    }
}
