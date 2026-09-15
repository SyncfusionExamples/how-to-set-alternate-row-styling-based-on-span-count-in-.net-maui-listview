# How to achieve alternate row styling on grid layout view in .NET MAUI ListView (SfListView)?

The [ .NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) enables you to apply alternate coloring for each item in a grid layout using the [SpanCount](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.GridLayout.html#Syncfusion_Maui_ListView_GridLayout_SpanCount) property. This is accomplished by finding the item index within the data collection using an `IValueConverter`.

Create an `SfListView` with `GridLayout` settings in XAML and bind it to the data source.

**XAML:**
```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.Maui.ListView;assembly=Syncfusion.Maui.ListView">

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:IndexToColorConverter x:Key="IndexToColorConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>
    <ContentPage.BindingContext>
        <local:ContactsViewModel x:Name="viewModel"/>
    </ContentPage.BindingContext>

    <ContentPage.Content>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>

            <syncfusion:SfListView x:Name="listView" SelectionMode="Multiple" 
                                   ItemSpacing="1" ItemSize="150"
                                   ItemsSource="{Binding Items}">
                <syncfusion:SfListView.ItemsLayout>
                    <syncfusion:GridLayout x:Name="grid" SpanCount="4" />
                </syncfusion:SfListView.ItemsLayout>
                <syncfusion:SfListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <ViewCell.View>
                                <Grid x:Name="grid" RowSpacing="0"
                                      BackgroundColor="{Binding .,Converter={StaticResource IndexToColorConverter},ConverterParameter={x:Reference Name=listView}}">
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="*" />
                                        <RowDefinition Height="1" />
                                    </Grid.RowDefinitions>
                                    <Grid RowSpacing="0">
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto" />
                                        </Grid.ColumnDefinitions>
                                        <Grid Grid.Column="1" RowSpacing="1" Padding="10,0,0,0" VerticalOptions="Center">
                                            <Grid.RowDefinitions>
                                                <RowDefinition Height="*" />
                                                <RowDefinition Height="*" />
                                            </Grid.RowDefinitions>
                                            <Label LineBreakMode="NoWrap" Text="{Binding ContactName}"/>
                                            <Label Grid.Row="1" Grid.Column="0" TextColor="#474747" LineBreakMode="NoWrap" Text="{Binding ContactNumber}">
                                            </Label>
                                        </Grid>
                                    </Grid>
                                </Grid>
                            </ViewCell.View>
                        </ViewCell>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

**C#:**
```
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
```

**Output:**
 
 ![AlternateRowStyle.PNG](https://support.syncfusion.com/kb/attachment/article/14880/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE2Njk3Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.3IZNDdwP7cKhGlocHpfbRXgQy3aLyMvGzsGX6eQGh4s)


**Conclusion**

I hope you enjoyed learning how to achieve alternate row styling on grid layout view based on span count in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications. Explore our [.NET MAUI ListView example](https://github.com/syncfusion/maui-demos/tree/master/MAUI/ListView) to understand how to create and manipulate data.

You can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui/confirm) to check out our other controls.

Please let us know in the comments section below if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
