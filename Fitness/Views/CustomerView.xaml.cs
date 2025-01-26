using Fitness.Repository;
using Fitness.ViewModel;
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

namespace Fitness.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            LoadVisitorsData();
        }
        private void LoadVisitorsData()
        {
            var repository = new VisitorsRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true"); 
            var visitors = repository.GetAllVisitors();
            CustomersDG.ItemsSource = visitors;
        }

        private void ButtonAddCustomers_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerView AddNewCustomer = new NewCustomerView();
            
            AddNewCustomer.ShowDialog();
        }
        private void ButtonRemoveCustomers_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonEditCustomers_Click(object sender, RoutedEventArgs e)
        {
            EditCustomerView AddNewCustomer = new EditCustomerView();

            AddNewCustomer.ShowDialog();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
