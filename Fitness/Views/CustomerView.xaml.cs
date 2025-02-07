using Fitness.EntityFramework.DataModel;
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
            CustomersDG.ItemsSource = FitnessGymEntities.GetContext().Visitors.ToList();
          
        }

        private void ButtonAddCustomers_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerView AddNewCustomer = new AddCustomerView((null)); 
            

            AddNewCustomer.ShowDialog();

        }
        private void ButtonRemoveCustomers_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = CustomersDG.SelectedItems.Cast<Visitors>().ToList();

            if (MessageBox.Show($"Удалить заявку?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FitnessGymEntities.GetContext().Visitors.RemoveRange(selectedCustomer);
                    FitnessGymEntities.GetContext().SaveChanges();
                    MessageBox.Show("Заявка удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    CustomersDG.ItemsSource = FitnessGymEntities.GetContext().Visitors.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void ButtonEditCustomers_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FitnessGymEntities())
            {
                var searchText = FilterTextBox.Text; var customer = context.Visitors.Where(r =>
                    r.FullName.Contains(searchText) ||
                    r.Email.Contains(searchText) || r.PhoneNumber.Contains(searchText) ||
                    r.SubscriptionType.Contains(searchText) || r.SubscriptionStatus.ToString().Contains(searchText)).ToList();
                CustomersDG.ItemsSource = customer;
            }
        }
    }
}
