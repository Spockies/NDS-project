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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private bool mngrActive = false;    //True if courier exist, false otherwise

        public Window1()
        {
            InitializeComponent();
        }

        private void btn_MngrSubmit_Click(object sender, RoutedEventArgs e)
        {

            //Retrieves info for database insertion
            //NameTxtBox.Text
            //AddressTxtBox.Text
            //PublicationTxtBox.Text
            //MonthlyTxtBox.Text
            //GeoRankTxtBox.Text
            //ImportantNoteTxtBox.Text
            //CourierAssignTxtBox.Text

            //Insert into listbox with name as "key"
            Label tempLabel = new Label();
            tempLabel.Content = NameTxtBox.Text;

            CustomerList_MngView.Items.Add(tempLabel);

            //clears fields then disable form

            NameTxtBox.Text="";
            AddressTxtBox.Text = "";
            PublicationTxtBox.Text="";
            MonthlyTxtBox.Text="";
            GeoRankTxtBox.Text="";
            ImportantNoteTxtBox.Text="";
            CourierAssignTxtBox.Text = "";
            chkbox_Inactive.IsEnabled=true;

            //disable form
            StkPnl_CustomerForm.IsEnabled = false;
        }

        private void btn_CourierMngView_Click(object sender, RoutedEventArgs e)
        {
            //Window switch

        }

        private void chkbox_Inactive_Checked(object sender, RoutedEventArgs e)
        {
            if (chkbox_Inactive.IsChecked==true)
            {
                //Set inactive in database
            }
        }
        
        private void btn_AddCourier_Click(object sender, RoutedEventArgs e)
        {
            CourierDialog courierNameDialog = new CourierDialog();
            if (courierNameDialog.ShowDialog() == true)
            {
                string temp = courierNameDialog.Courier_name;               //Fetch Courier name; Doesn't implement proper name checking
                // Code for database insert of courier name

                //code to put courier button in courier name listbox

                Button tempButton = new Button();
                tempButton.Content = temp;
                //Find a way to widen button to fill up listbox pane


                tempButton.Click+=new RoutedEventHandler(RemoveCourierButton);

                CourierList_MngView.Items.Add(tempButton);

                mngrActive = true;
            }

            if (mngrActive)
            {
                
                btn_AddCustomer.IsEnabled = true;
            }

        }

        //Deletes Courier button
        private void RemoveCourierButton(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            CourierList_MngView.Items.Remove(currentButton);

            //if no courier, disable adding more customers
            if (CourierList_MngView.Items.IsEmpty)
            {
                mngrActive = false;
                btn_AddCustomer.IsEnabled = false;
            }
        }

        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Enable Customer info to be filled in the form
            StkPnl_CustomerForm.IsEnabled = true;
            chkbox_Inactive.IsEnabled = false;
        }
        //Event For customer selected in manager view
        private void CustomerList_MngView_Selected(object sender, RoutedEventArgs e)
        {
            //Traverses controls to get key
            ListBox customerBox = sender as ListBox;
            Label customerLabel = customerBox.SelectedItem as Label;

            //Key
            //customerLabel.Content;


            //Retrieve info from database to insert to edit form using the name as "key"


            //Fields to fill info
            //NameTxtBox.Text
            //AddressTxtBox.Text
            //PublicationTxtBox.Text
            //MonthlyTxtBox.Text
            //GeoRankTxtBox.Text
            //ImportantNoteTxtBox.Text
            //CourierAssignTxtBox.Text
        }

    }
}
