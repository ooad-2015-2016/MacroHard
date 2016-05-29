using Shem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace ShEM.ViewModel
{
    public class EditAccountViewModel
    {
        public CameraHelper camerHelper { get; set; }
        byte[] picture;

        public async Task<byte[]> getPicture()
        {
           //fkt ne znam kako uraditi 


            return picture;
        }
    }
}
