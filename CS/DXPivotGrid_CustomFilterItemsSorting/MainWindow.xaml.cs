using System.Collections;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DXPivotGrid_CustomFilterItemsSorting.DataSet1TableAdapters;

namespace DXPivotGrid_CustomFilterItemsSorting {
    public partial class MainWindow : Window {
        DataSet1.SalesPersonDataTable salesPersonDataTable = new DataSet1.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();
        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = salesPersonDataAdapter.GetData();
        }
        private void pivotGridControl1_CustomFilterPopupItems(object sender,
                                    PivotCustomFilterPopupItemsEventArgs e) {
            if (rbCaptionLength.IsChecked == true)
                ArrayList.Adapter((IList)e.Items).Sort(new FilterItemsComparer());
        }
    }
    public class FilterItemsComparer : IComparer {
        int IComparer.Compare(object x, object y) {
            if (!(x is PivotGridFilterItem) || !(y is PivotGridFilterItem)) return 0;
            PivotGridFilterItem item1 = (PivotGridFilterItem)x;
            PivotGridFilterItem item2 = (PivotGridFilterItem)y;
            if (item1.ToString().Length == item2.ToString().Length) return 0;
            if (item1.ToString().Length > item2.ToString().Length) return 1;
            return -1;
        }
    }
}
