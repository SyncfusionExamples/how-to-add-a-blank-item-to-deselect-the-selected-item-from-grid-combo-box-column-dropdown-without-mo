# How to add a blank item to deselect the selected item from GridComboBoxColumn dropdown without modifying actual source in WPF DataGrid?

## About the sample

This sample illustrates how to add a blank item to deselect the selected item from GridComboBoxColumn dropdown without modifying actual source in WPF DataGrid.

By default, [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid)(SfDataGrid) [GridComboBoxColumn](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridComboBoxColumn.html) doesn’t have any direct support to add blank item without modifying the ItemsSource of the GridComboBoxColumn. However, you can add blank item to the dropdown by adding a ComboBoxItem to GridComboBoxColumn.ItemsSource. 

```Xaml

<Window.Resources>
     <CollectionViewSource x:Key="ComboBoxItems" Source="{Binding Countries}" />
</Window.Resources>

<Grid>
    <syncfusion:SfDataGrid Name="dataGrid"
                           AutoGenerateColumns="False"
                           ItemsSource="{Binding Employees}">

        <syncfusion:SfDataGrid.Columns>
            <syncfusion:GridComboBoxColumn MappingName="Country">
                <syncfusion:GridComboBoxColumn.ItemsSource>
                    <CompositeCollection>
                        <ComboBoxItem Content="Blank"/>
                        <CollectionContainer Collection="{Binding Source={StaticResource ComboBoxItems}}" />
                    </CompositeCollection>
                </syncfusion:GridComboBoxColumn.ItemsSource>
            </syncfusion:GridComboBoxColumn>
        </syncfusion:SfDataGrid.Columns>

    </syncfusion:SfDataGrid>
</Grid>

```

You can set the SelectedItem of the ComboBox to null when the blank item is selected by creating custom renderer for the GridComboBoxcolumn.

``` c#

public MainWindow()
 {
     InitializeComponent();
     this.dataGrid.CellRenderers["ComboBox"] = new CustomComboBoxCellRenderer();
 }

public class CustomComboBoxCellRenderer : GridCellComboBoxRenderer
{
    public override void OnInitializeEditElement(DataColumnBase dataColumn, ComboBox uiElement, object dataContext)
    {
        uiElement.SelectionChanged += ComboBox_SelectionChanged;
        base.OnInitializeEditElement(dataColumn, uiElement, dataContext);
    }

    private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 1 && e.AddedItems[0] is ComboBoxItem && (e.AddedItems[0] as ComboBoxItem).Content.ToString() == "Blank")
            (sender as ComboBox).SelectedItem = null;
    }
}

```

![GridComboBoxColumn with blank item](ComboBox_BlankItem.png)

KB article - [How to add a blank item to deselect the selected item from GridComboBoxColumn dropdown without modifying actual source in WPF DataGrid?](https://www.syncfusion.com/kb/12382/how-to-add-a-blank-item-to-deselect-the-selected-item-from-gridcomboboxcolumn-dropdown)

## Requirements to run the demo
Visual Studio 2015 and above versions



