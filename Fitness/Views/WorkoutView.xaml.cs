using Fitness.Repository;
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
            var repository = new WorkoutRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true"); // Ваш класс для работы с базой
            var workout = repository.GetAllWorkout();
            WorkoutDG.ItemsSource = workout; // Устанавливаем источник данных для DataGrid
        }
    }
}