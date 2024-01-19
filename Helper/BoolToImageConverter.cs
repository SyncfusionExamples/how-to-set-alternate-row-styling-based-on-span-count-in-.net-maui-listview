using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class IndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listview = parameter as SfListView;
            var index = listview.DataSource.DisplayItems.IndexOf(value);
            int spanCount = ((Syncfusion.Maui.ListView.GridLayout)listview.ItemsLayout).SpanCount;
            Color CornBlue = Colors.CornflowerBlue;
            Color Blue = Colors.LightBlue;

            if (spanCount % 2 == 1)
            {
                return index % 2 == 0 ? CornBlue : Blue;
            }
            else
            {
                int row = index / spanCount;
                if (row % 2 == 0)
                {
                    return index % 2 == 0 ? CornBlue : Blue;
                }
                else
                {
                    return index % 2 == 0 ? Blue : CornBlue;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
