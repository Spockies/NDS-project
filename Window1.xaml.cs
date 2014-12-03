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
        private List<Customer> _customers;      //contains active and inactive customers
        private List<Courier> _couriers;        //contains active and inactive couriers

        private bool mngrActive = false;    //True if courier exist, false otherwise

        public Window1()
        {
            InitializeComponent();
        }

        //Used when adding to the database a new customer
        private void btn_MngrSubmit_Click(object sender, RoutedEventArgs e)
        {

            //Retrieves info for database insertion as strings

            string name = NameTxtBox.Text;
            string address = AddressTxtBox.Text;
            //PublicationTxtBox.Text
            //MonthlyTxtBox.Text
            //GeoRankTxtBox.Text
            //ImportantNoteTxtBox.Text
            //CourierAssignTxtBox.Text

            //Insert into listbox with name string as the "key"
            ListBoxItem tempItem = new ListBoxItem();
            tempItem.Content = NameTxtBox.Text;

            //Set up context menu on right click for editing or delete
            tempItem.ContextMenu = this.FindResource("editContextMenu") as ContextMenu;

            //Adds right click function to edit selected field
            CustomerList_MngView.Items.Add(tempItem);

            //clears fields then disable form

            clearDataFields();
            chkbox_Inactive.IsEnabled=true;

            //disable form
            StkPnl_CustomerForm.IsEnabled = false;
        }

        private void clearDataFields()
        {
            NameTxtBox.Text = "";
            AddressTxtBox.Text = "";
            PublicationTxtBox.Text = "";
            MonthlyTxtBox.Text = "";
            GeoRankTxtBox.Text = "";
            ImportantNoteTxtBox.Text = "";
            CourierAssignTxtBox.Text = "";
        }

        private void btn_CourierMngView_Click(object sender, RoutedEventArgs e)
        {
            //Must save to database?
            //Maybe not necessary if database is change whenever modified and new additions

            //Code before this

            //Window switch
            MainWindow courier = new MainWindow();
            courier.Left = this.Left;
            courier.Top = this.Top;
            
            courier.Show();
            this.Close();
        }

        private void chkbox_Inactive_Checked(object sender, RoutedEventArgs e)
        {
            if (chkbox_Inactive.IsChecked==true)
            {

                //Set activity in database to false
            }
            else 
            { 
                //reset activity field to true
            }

                
        }
        
        private void btn_AddCourier_Click(object sender, RoutedEventArgs e)
        {
            CourierDialog courierNameDialog = new CourierDialog();
            if (courierNameDialog.ShowDialog() == true)
            {
                string tempName = courierNameDialog.Courier_name;               //Fetch Courier name; Doesn't implement proper name checking
                
                //********************Database insertion for a new courier and active state to true
                



                //Creates new object in current _courier list but has no customer attached.
                Courier tempCourier = new Courier(tempName, true);
                _couriers.Add(tempCourier);


                //code to put courier button in courier name listbox

                //CourierList_MngView.Items.Add(tempCourier);

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

            //Removal of courier shouldn't delete field in database
            //Extra column 'Active' set as a boolean
            //query to false when this button event occurs
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
            //Enable new Customer info to be filled in the form
            clearDataFields();
            //Edit/Submit button swapping
            btn_MngrSubmit.Visibility = Visibility.Visible;
            btn_MngrEdit.Visibility = Visibility.Hidden;

            StkPnl_CustomerForm.IsEnabled = true;
            chkbox_Inactive.IsEnabled = false;
        }
        //Event For customer selected in manager view, read-only mode; right click for option to edit
        private void CustomerList_MngView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If enabled already, then disable
            if (StkPnl_CustomerForm.IsEnabled == true)
            {
                StkPnl_CustomerForm.IsEnabled = false;
            }
            //Traverses controls to get key
            ListBoxItem customerItem = ((sender as ListBox).SelectedItem as ListBoxItem);
            

            //Key 
            //customerItem.Content.ToString();

            NameTxtBox.Text = customerItem.Content.ToString();

            string name = NameTxtBox.Text;
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

        //Rightclick option
        private void MenuItem_Edit_Click(object sender, RoutedEventArgs e)
        {
            //Swap Edit/Submit buttons
            btn_MngrSubmit.Visibility = Visibility.Hidden;
            btn_MngrEdit.Visibility = Visibility.Visible;
            StkPnl_CustomerForm.IsEnabled = true;


            //Decision? 
            //***************************************************
            //When editing customer data, the key should not be altered which in this current iteration is the name.

            NameTxtBox.IsEnabled = false;
        }
        //Rightclick option
        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_MngrEdit_Click(object sender, RoutedEventArgs e)
        {
            //Retrieve all info on customer form and update database
            //Name is the "key"


            //NameTxtBox.Text
            //AddressTxtBox.Text
            //PublicationTxtBox.Text
            //MonthlyTxtBox.Text
            //GeoRankTxtBox.Text
            //ImportantNoteTxtBox.Text
            //CourierAssignTxtBox.Text

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   //When window is activated, populate courier and customer list from database
            //then render to the listboxes the courier info and customer info respectively
            Courier_Fetch();
            Customer_Fetch();
            Populate_Courier_Box();
            Populate_Customer_Box();
        }
        private void Courier_Fetch()
        {
            //Code here for connecting to database and adding to the list _couriers
            //_couriers is the list of all couriers in the database, active or not

        }
        private void Customer_Fetch()
        {
            //Code here for connecting to database and adding to the list _customers
            //_customer is the list of all customers in the database, active or not
        }
        private void Populate_Courier_Box()
        {
            //****Uncomment when _courier is populated*****

            //*****************ENDOF Uncomment here when everything is loaded*******************
        }
        private void Populate_Customer_Box()
        {
            //****Uncomment when _customer is populated*****

            //*****************ENDOF Uncomment here when everything is loaded*******************
        }
    }
}
