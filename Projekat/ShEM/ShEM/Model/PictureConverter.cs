using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ShEM.BazaPodataka.Views
{
    public class PictureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is byte[])) return null;
            
            using(InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using(DataWriter dw = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    dw.WriteBytes((byte[])value);
                    dw.StoreAsync().GetResults();
                }
                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            } 
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
