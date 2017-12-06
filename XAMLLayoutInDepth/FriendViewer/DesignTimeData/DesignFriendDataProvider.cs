using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendViewer.DataProvider;
using FriendViewer.Model;

namespace FriendViewer.DesignTimeData
{
    public class DesignFriendDataProvider : IFriendDataProvider
    {
        public IEnumerable<Friend> LoadFriends()
        {
            yield return new DesignFriend();
            yield return new DesignFriend { FirstName = "Julia" };
            yield return new DesignFriend { FirstName = "Anna" };
            yield return new DesignFriend { FirstName = "Sara" };
        }
    }
}
