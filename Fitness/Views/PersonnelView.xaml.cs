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
            var repository = new PersonnelRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true"); // Ваш класс для работы с базой
            var personnel = repository.GetAllPersonnel();
            PersonnelDG.ItemsSource = personnel; // Устанавливаем источник данных для DataGrid
        }
    }
}
