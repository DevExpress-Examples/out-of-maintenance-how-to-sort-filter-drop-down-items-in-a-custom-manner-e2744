Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DXPivotGrid_CustomFilterItemsSorting.DataSet1TableAdapters

Namespace DXPivotGrid_CustomFilterItemsSorting
	Partial Public Class MainWindow
		Inherits Window
		Private salesPersonDataTable As New DataSet1.SalesPersonDataTable()
		Private salesPersonDataAdapter As New SalesPersonTableAdapter()
		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = salesPersonDataAdapter.GetData()
		End Sub
		Private Sub pivotGridControl1_CustomFilterPopupItems(ByVal sender As Object, _
				ByVal e As PivotCustomFilterPopupItemsEventArgs)
			If rbCaptionLength.IsChecked = True Then
				ArrayList.Adapter(CType(e.Items, IList)).Sort(New FilterItemsComparer())
			End If
		End Sub
	End Class
	Public Class FilterItemsComparer
		Implements IComparer
		Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer _
							Implements IComparer.Compare
			If Not(TypeOf x Is PivotGridFilterItem) OrElse _
				Not(TypeOf y Is PivotGridFilterItem) Then
				Return 0
			End If
			Dim item1 As PivotGridFilterItem = CType(x, PivotGridFilterItem)
			Dim item2 As PivotGridFilterItem = CType(y, PivotGridFilterItem)
			If item1.ToString().Length = item2.ToString().Length Then
				Return 0
			End If
			If item1.ToString().Length > item2.ToString().Length Then
				Return 1
			End If
			Return -1
		End Function
	End Class
End Namespace
