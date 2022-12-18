Imports System.Collections
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DXPivotGrid_CustomFilterItemsSorting.DataSet1TableAdapters

Namespace DXPivotGrid_CustomFilterItemsSorting

    Public Partial Class MainWindow
        Inherits Window

        Private salesPersonDataTable As DataSet1.SalesPersonDataTable = New DataSet1.SalesPersonDataTable()

        Private salesPersonDataAdapter As SalesPersonTableAdapter = New SalesPersonTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = salesPersonDataAdapter.GetData()
        End Sub

        Private Sub pivotGridControl1_CustomFilterPopupItems(ByVal sender As Object, ByVal e As PivotCustomFilterPopupItemsEventArgs)
            If Me.rbCaptionLength.IsChecked = True Then Call ArrayList.Adapter(CType(e.Items, IList)).Sort(New FilterItemsComparer())
        End Sub
    End Class

    Public Class FilterItemsComparer
        Implements IComparer

        Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            If Not(TypeOf x Is PivotGridFilterItem) OrElse Not(TypeOf y Is PivotGridFilterItem) Then Return 0
            Dim item1 As PivotGridFilterItem = CType(x, PivotGridFilterItem)
            Dim item2 As PivotGridFilterItem = CType(y, PivotGridFilterItem)
            If item1.ToString().Length = item2.ToString().Length Then Return 0
            If item1.ToString().Length > item2.ToString().Length Then Return 1
            Return -1
        End Function
    End Class
End Namespace
