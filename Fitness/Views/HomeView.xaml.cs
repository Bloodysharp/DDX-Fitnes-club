
using Fitness.EntityFramework.DataModel;
using Fitness.Repository;
using Fitness.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> ItemLabels { get; set; }
        public List<string> PersonnelLabels { get; set; }
        public List<string> VisitorLabels { get; set; }
        public Func<double, string> YAxisFormatter { get; set; }

      

        public HomeView()
        {
            InitializeComponent();
            
            var connectionString = "Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true";
            var inventoryService = new InventoryRepository(connectionString);

         
            var inventoryData = inventoryService.GetAllInventory();

         
            var quantityValues = new ChartValues<int>();
            var inRepairValues = new ChartValues<int>();
            ItemLabels = new List<string>();

            foreach (var item in inventoryData)
            {
                ItemLabels.Add(item.Name);
                quantityValues.Add(item.Quantity);
                inRepairValues.Add(item.InRepair);
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Кол-во",
                    Values = quantityValues
                },
                new ColumnSeries
                {
                    Title = "В ремонте",
                    Values = inRepairValues
                }
            };

            YAxisFormatter = value => value.ToString("N0");

            // Bind to chart
            InventoryChart.Series = SeriesCollection;
            InventoryChart.AxisX[0].Labels = ItemLabels;

            /////////////////////////////////////////////////////////////////

            var personnelService = new PersonnelRepository(connectionString);

            // Fetch data
            var personnelData = personnelService.GetAllPersonnel();

            // Prepare chart data
            var salaryValues = new ChartValues<decimal>();
            PersonnelLabels = new List<string>();

            foreach (var person in personnelData)
            {
                PersonnelLabels.Add(person.FullName);
                salaryValues.Add(person.Salary);
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Salary",
                    Values = salaryValues
                }
            };

            YAxisFormatter = value => $"${value:N0}";

            // Bind to chart
            PersonnelChart.Series = SeriesCollection;
            PersonnelChart.AxisX[0].Labels = PersonnelLabels;

            /////////////////////////////////////////////////



            // Replace with your actual connection string
           
            var visitorService = new VisitorsRepository(connectionString);

            // Fetch data
            var visitorData = visitorService.GetAllVisitors();

            // Prepare chart data
            var priceValues = new ChartValues<decimal>();
            VisitorLabels = new List<string>();

            foreach (var visitor in visitorData)
            {
                VisitorLabels.Add(visitor.FullName); // X-axis labels
                priceValues.Add(visitor.SubscriptionPrice); // Y-axis values
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Subscription Price",
                    Values = priceValues
                }
            };

            YAxisFormatter = value => $"${value:N2}";

            // Bind to chart
            VisitorsChart.Series = SeriesCollection;
            VisitorsChart.AxisX[0].Labels = VisitorLabels;
        }
    }
}