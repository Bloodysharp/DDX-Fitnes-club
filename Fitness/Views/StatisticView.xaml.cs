using DDX_Fitness.ViewModel;
using Fitness.Model;
using Fitness.Repository;
using Fitness.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для StatisticView.xaml
    /// </summary>
    public partial class StatisticView : UserControl, INotifyPropertyChanged
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<decimal, string> YFormatter { get; set; }
        public StatisticView()
        {
            InitializeComponent();
            DataContext = this;

            var connectionString = "Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true";
            var statsRepository = new StatisticRepository(connectionString);

            // Получение данных из базы
            var stats = statsRepository.GetAllStatts();

            // Подготовка данных для графиков
            PreparePribilChart(stats);
            PrepareTratiChart(stats);
            PrepareZpChart(stats);
        }

        private void PreparePribilChart(IEnumerable<StatisticModel> stats)
        {
            var totalRevenues = new ChartValues<decimal>();
            Labels = new List<string>();

            foreach (var item in stats)
            {
                Labels.Add(item.MonthYear.ToString("MMMM yyyy"));
                totalRevenues.Add(item.TotalSubscriptionsRevenue);
            }

            SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Общая прибыль",
                Values = totalRevenues
            }
        };

            pribil.Series = SeriesCollection;
            pribil.AxisX[0].Labels = Labels;
            YFormatter = value => $"₽ {value:N0}";

            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(Labels));
            OnPropertyChanged(nameof(YFormatter));
        }

        private void PrepareTratiChart(IEnumerable<StatisticModel> stats)
        {
            var repaircost = new ChartValues<decimal>();
            var newEquip = new ChartValues<decimal>();
            Labels = new List<string>();

            foreach (var item in stats)
            {
                Labels.Add(item.MonthYear.ToString("MMMM yyyy"));
                repaircost.Add(item.RepairCosts);
                newEquip.Add(item.EquipmentPurchaseCosts);
            }

            SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Закупка нового оборудования",
                Values = newEquip
            },
            new ColumnSeries
            {
                Title = "Издержки на ремонт",
                Values = repaircost
            }
        };

            trati.Series = SeriesCollection;
            trati.AxisX[0].Labels = Labels;
            YFormatter = value => $"₽ {value:N0}";

            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(Labels));
            OnPropertyChanged(nameof(YFormatter));
        }

        private void PrepareZpChart(IEnumerable<StatisticModel> stats)
        {
            var managerSalaries = new ChartValues<decimal>();
            var trainerSalaries = new ChartValues<decimal>();
            Labels = new List<string>();

            foreach (var item in stats)
            {
                Labels.Add(item.MonthYear.ToString("MMMM yyyy"));
                managerSalaries.Add(item.ManagersSalaryExpense);
                trainerSalaries.Add(item.TrainersSalaryExpense);
            }

            SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Зарплата менеджеров",
                Values = managerSalaries
            },
            new ColumnSeries
            {
                Title = "Зарплата тренеров",
                Values = trainerSalaries
            }
        };

            zp.Series = SeriesCollection;
            zp.AxisX[0].Labels = Labels;
            YFormatter = value => $"₽ {value:N0}";

            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(Labels));
            OnPropertyChanged(nameof(YFormatter));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
