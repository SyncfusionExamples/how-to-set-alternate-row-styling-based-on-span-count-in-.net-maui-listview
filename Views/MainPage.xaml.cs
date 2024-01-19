using Syncfusion.Maui.ListView;

namespace ListViewMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listView.QueryItemSize += ListView_QueryItemSize;
        }

        private void ListView_QueryItemSize(object sender, QueryItemSizeEventArgs e)
        {
            if (e.ItemIndex % 2 == 0)
                e.ItemSize = 50;
            else
                e.ItemSize = 100;
            e.Handled = true;
        }
    }
}
