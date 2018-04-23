using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopupMenu {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Finish BarManager initialization (to allow its further customization on the form load)
            barManager1.ForceInitialize();

            DevExpress.XtraBars.PopupMenu menu = new DevExpress.XtraBars.PopupMenu();
            menu.Manager = barManager1;
            barManager1.Images = imageCollection1;
            BarButtonItem itemCopy = new BarButtonItem(barManager1, "Copy", 0);
            BarButtonItem itemPaste = new BarButtonItem(barManager1, "Paste", 1);
            BarButtonItem itemRefresh = new BarButtonItem(barManager1, "Refresh", 2);
            menu.AddItems(new BarItem[] { itemCopy, itemPaste, itemRefresh });
            // Create a separator before the Refresh item.
            itemRefresh.Links[0].BeginGroup = true;
            // Process item clicks.
            barManager1.ItemClick += BarManager1_ItemClick;
            // Associate the popup menu with the form.
            barManager1.SetPopupContextMenu(this, menu);
        }

        private void BarManager1_ItemClick(object sender, ItemClickEventArgs e) {
            XtraMessageBox.Show(e.Item.Caption + " item clicked");
        }
    }
}
