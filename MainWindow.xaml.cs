using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfDataGrid_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid.CellRenderers["ComboBox"] = new CustomComboBoxCellRenderer();
        }
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
}
