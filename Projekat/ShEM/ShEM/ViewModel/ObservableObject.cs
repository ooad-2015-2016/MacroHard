using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.ViewModel
{
    class ObservableObject : INotifyPropertyChanged
    {
        public ObservableObject()
        {

        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        PropertyChangedEventHandler propertyChanged;
        private void notifyPropertyChanged(string info)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
