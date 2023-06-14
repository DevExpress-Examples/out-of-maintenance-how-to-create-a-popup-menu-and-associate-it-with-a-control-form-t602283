Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace PopupMenu

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Finish BarManager initialization (to allow its further customization on the form load)
            barManager1.ForceInitialize()
            Dim menu As DevExpress.XtraBars.PopupMenu = New DevExpress.XtraBars.PopupMenu()
            menu.Manager = barManager1
            barManager1.Images = imageCollection1
            Dim itemCopy As BarButtonItem = New BarButtonItem(barManager1, "Copy", 0)
            Dim itemPaste As BarButtonItem = New BarButtonItem(barManager1, "Paste", 1)
            Dim itemRefresh As BarButtonItem = New BarButtonItem(barManager1, "Refresh", 2)
            menu.AddItems(New BarItem() {itemCopy, itemPaste, itemRefresh})
            ' Create a separator before the Refresh item.
            itemRefresh.Links(0).BeginGroup = True
            ' Process item clicks.
            AddHandler barManager1.ItemClick, AddressOf BarManager1_ItemClick
            ' Associate the popup menu with the form.
            barManager1.SetPopupContextMenu(Me, menu)
        End Sub

        Private Sub BarManager1_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            XtraMessageBox.Show(e.Item.Caption & " item clicked")
        End Sub
    End Class
End Namespace
