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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S.E.NDS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Customer> _customers;      //contains active and inactive customers
        private List<Courier> _couriers;        //contains active and inactive couriers
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintBill_CrrView_Click(object sender, RoutedEventArgs e)
        {
            //*********Needs work on where it will be printed and how it will look like
            //          Maybe additional methods to format and organize printout
        }

        private void btn_Manager_CrrView_Click(object sender, RoutedEventArgs e)
        {
            //Must save to database?
            //Maybe not necessary as this is a Read-Only Window
            //Code before this
            Window1 manager = new Window1();
            manager.Left = this.Left;
            manager.Top = this.Top;

            manager.Show();
            this.Close();
        }

        private void Populate_Courier_Box()
        {   
            //****Uncomment when _courier is populated*****

            //Retrieve courier name from courier list of active couriers
            //foreach(Courier person in _couriers)
            //      {
            //          if (person.active == true)
            //              {
            //                  ListBoxItem courierData = new ListBoxItem();
            //                  courierData.Content = person.name;
            //                  CourierList_CrrView.Items.Add(courierData); 
            //              }
            //      }
            //*****************ENDOF Uncomment here when everything is loaded*******************
        }

        private void CourierList_CrrView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //reference to selected item
            ListBoxItem courierItem = ((sender as ListBox).SelectedItem as ListBoxItem);
            //Finds courier name selected
            string courierName = courierItem.Content.ToString();

            //*******Uncomment when _courier is loaded*********
            //Courier paperboy = _couriers.Find(x => x.name == courierName);

            ////List of strings for customerName belonging to paperboy:   paperboy.customerName
            //// Use it in conjunction with _customers to get customer object that are active
            ////then populate CrrCustomerinfo_CrrView

            ////Tracks which customer is active
            //List<Customer> activeCustomer= new List<Customer>();
            
            ////Finds all customers whom are active relative to courier selected
            //// and adds to the list activeCustomer
            //foreach( string customer in paperboy.customerName)
            //{
            //      Customer person = _customers.Find(x => x.name == customer);
            //      //Person must be active customer to be displayed as part of courier route
            //      if (person.isActive == true)
            //      {
            //          activeCustomer.Add(person);
            //      }
            //}

            
            ////List is populated now
            
            //CrrCustomerinfo_CrrView.ItemsSource = activeCustomer;
            //*****************ENDOF Uncomment here when everything is loaded*******************
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   //When window is activated, populate courier and customer list from database
            //then render to the listboxes the courier info
            Courier_Fetch();
            Customer_Fetch();
            Populate_Courier_Box();
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

        private void Print_Route_Click(object sender, RoutedEventArgs e)
        {
            //Prints routes based on currently selected courier
            //Manually print each route for each individual courier
        }

        private void Delivery_History_Click(object sender, RoutedEventArgs e)
        {
            //Delivery history is the entirety of the day of all active couriers
        }
    }
}
