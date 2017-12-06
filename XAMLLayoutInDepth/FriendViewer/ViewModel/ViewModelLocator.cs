using System.ComponentModel;
using System.Windows;
using FriendViewer.DataProvider;
using FriendViewer.DesignTimeData;

namespace FriendViewer.ViewModel
{
    public class ViewModelLocator
    {
        private MainViewModel _mainViewModel;

        public MainViewModel MainViewModel
        {
            get
            {
                if (_mainViewModel != null) return _mainViewModel;
                IFriendDataProvider dataProvider =
                    DesignerProperties.GetIsInDesignMode(new FrameworkElement())
                        ? (IFriendDataProvider)new DesignFriendDataProvider()
                        : new FriendDataProvider();
                _mainViewModel = new MainViewModel(dataProvider);
                return _mainViewModel;
            }
        }
    }
}