# how-to-set-alternate-row-styling-based-on-span-count-in-.net-maui-listview

This example demonstrates how to set alternate row styling on listview based on span count in .NET MAUI ListView (SfListView).

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:IndexToColorConverter x:Key="IndexToColorConverter"/>
    </ResourceDictionary>
</ContentPage.Resources>

<syncfusion:SfListView
    x:Name="listView"
    ItemSize="150"
    ItemSpacing="1"
    ItemsSource="{Binding Items}"
    SelectionMode="Multiple">

    <syncfusion:SfListView.ItemsLayout>
        <syncfusion:GridLayout x:Name="grid" SpanCount="4" />
    </syncfusion:SfListView.ItemsLayout>

    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <ViewCell.View>
                    <Grid
                        x:Name="grid"
                        BackgroundColor="{Binding ., Converter={StaticResource IndexToColorConverter}, ConverterParameter={x:Reference Name=listView}}"
                        RowSpacing="0">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                            <RowDefinition Height="1" />
                        </Grid.RowDefinitions>
                        <Grid RowSpacing="0">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>

                            <Grid
                                Grid.Column="1"
                                Padding="10,0,0,0"
                                RowSpacing="1"
                                VerticalOptions="Center">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*" />
                                    <RowDefinition Height="*" />
                                </Grid.RowDefinitions>

                                <Label LineBreakMode="NoWrap" Text="{Binding ContactName}" />
                                <Label
                                    Grid.Row="1"
                                    Grid.Column="0"
                                    LineBreakMode="NoWrap"
                                    Text="{Binding ContactNumber}"
                                    TextColor="#474747" />
                            </Grid>
                        </Grid>
                    </Grid>
                </ViewCell.View>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

```C#
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
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
