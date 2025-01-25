using Fitness.Model;
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
    /// Логика взаимодействия для InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            LoadInventoryData();
            
        }
        private void LoadInventoryData()
        {
            var repository = new InventoryRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true"); 
            var inventory = repository.GetAllInventory();
            InventoryDG.ItemsSource = inventory;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
           
        }

       
    }
}