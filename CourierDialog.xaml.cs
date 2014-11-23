using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace S.E.NDS
{
    /// <summary>
    /// Interaction logic for CourierDialog.xaml
    /// </summary>
    public partial class CourierDialog : Window
    {
        public string Courier_name
        {
            get { return CourierName.Text; }
        }
        
        public CourierDialog()
        {
            InitializeComponent();
        }

        private void btn_CourierOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
