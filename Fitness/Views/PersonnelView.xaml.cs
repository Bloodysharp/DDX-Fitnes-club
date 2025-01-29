
using Fitness.EntityFramework.DataModel;
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
    /// Логика взаимодействия для PersonnelView.xaml
    /// </summary>
    public partial class PersonnelView : UserControl
    {
        public PersonnelView()
        {
            InitializeComponent();
            PersonnelDataLoad();
        }
        private void PersonnelDataLoad()
        {
            PersonnelDG.ItemsSource = FitnessGymEntities.GetContext().Trainers.ToList();
        }


        private void ButtonAddPersonnel_Click(object sender, RoutedEventArgs e)
        {
            AddPersonnelView AddNewCustomer = new AddPersonnelView((null));


            AddNewCustomer.ShowDialog();

        }
        private void ButtonRemoveTrainers_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = PersonnelDG.SelectedItems.Cast<Trainers>().ToList();

            if (MessageBox.Show($"Удалить заявку?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FitnessGymEntities.GetContext().Trainers.RemoveRange(selectedCustomer);
                    FitnessGymEntities.GetContext().SaveChanges();
                    MessageBox.Show("Заявка удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    PersonnelDG.ItemsSource = FitnessGymEntities.GetContext().Trainers.ToList();
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
                var searchText = FilterTextBox.Text; var customer = context.Trainers.Where(r =>
                    r.FullName.Contains(searchText) ||
                    r.Email.Contains(searchText) || r.PhoneNumber.Contains(searchText) ||
                    r.Specialty.Contains(searchText) || r.ExperienceYears.ToString().Contains(searchText)).ToList();


                PersonnelDG.ItemsSource = customer;
            }
        }
    }
}
