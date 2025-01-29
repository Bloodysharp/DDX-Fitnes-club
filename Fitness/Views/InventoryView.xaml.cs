
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
    /// Логика взаимодействия для InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            LoadEquipmentData();
            
        }
        private void LoadEquipmentData()
        {
            InventoryDG.ItemsSource = FitnessGymEntities.GetContext().Equipment.ToList();
        }

        private void ButtonAddPersonnel_Click(object sender, RoutedEventArgs e)
        {
            AddInventoryView AddNewCustomer = new AddInventoryView((null));


            AddNewCustomer.ShowDialog();

        }
        private void ButtonRemoveTrainers_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = InventoryDG.SelectedItems.Cast<Equipment>().ToList();

            if (MessageBox.Show($"Удалить заявку?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FitnessGymEntities.GetContext().Equipment.RemoveRange(selectedCustomer);
                    FitnessGymEntities.GetContext().SaveChanges();
                    MessageBox.Show("Заявка удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    InventoryDG.ItemsSource = FitnessGymEntities.GetContext().Equipment.ToList();
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
                var searchText = FilterTextBox.Text; var customer = context.Equipment.Where(r =>
                    r.Name.Contains(searchText) ||
                    r.Status.Contains(searchText) || r.InRepair.ToString().Contains(searchText) ||
                    r.Quantity.ToString().Contains(searchText) || r.Price.ToString().Contains(searchText)).ToList();


                InventoryDG.ItemsSource = customer;
            }
        }


    }
}