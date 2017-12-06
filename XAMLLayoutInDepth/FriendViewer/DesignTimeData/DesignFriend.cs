using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FriendViewer.Model;

namespace FriendViewer.DesignTimeData
{
    public class DesignFriend : Friend
    {
        public DesignFriend()
        {
            FirstName = "Thomas";
            LastName = "Huber";
            CellPhone = "+49 (0) 1234567890";
            Email = "thomas@thomasclaudiushuber.com";
            Homepage = "www.thomasclaudiushuber.com";
            SetImageProperty();
        }

        private void SetImageProperty()
        {
            var streamResourceInfo =
                Application.GetResourceStream(
                    new Uri("FriendViewer;component/DesignTimeData/Images/thomas.jpg", UriKind.Relative));

            if (streamResourceInfo == null) return;
            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int) length);

            Image = image;
        }
    }
}