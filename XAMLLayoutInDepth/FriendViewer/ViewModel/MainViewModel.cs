using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendViewer.DataProvider;
using FriendViewer.Model;

namespace FriendViewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IFriendDataProvider _dataProvider;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }
        public Friend SelectedFriend
        {
            get => _selectedFriend;
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<Friend>();
            LoadData();
        }

        private void LoadData()
        {
            var friends = _dataProvider.LoadFriends();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }

            SelectedFriend = Friends.Count > 0 ? Friends.First() : null;
        }
    }
}