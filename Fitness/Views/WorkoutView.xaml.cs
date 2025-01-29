
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
    /// Логика взаимодействия для WorkoutView.xaml
    /// </summary>
    public partial class WorkoutView : UserControl
    {
        public WorkoutView()
        {
            InitializeComponent();
            LoadWorkoutData();
        }
        private void LoadWorkoutData()
        {
            WorkoutDG.ItemsSource = FitnessGymEntities.GetContext().Workouts.ToList();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FitnessGymEntities())
            {
                var searchText = FilterTextBox.Text; var customer = context.Workouts.Where(r =>
                    r.Name.Contains(searchText) ||
                    r.TrainerFullName.Contains(searchText) || r.StartTime.Contains(searchText) ||
                    r.EndTime.Contains(searchText) || r.TotalTime.ToString().Contains(searchText)).ToList();


                WorkoutDG.ItemsSource = customer;
            }
        }
    }
}