using DDX_Fitness.ViewModel;
using Fitness.Model;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Fitness.Repository;
using System.Collections.ObjectModel;

namespace Fitness.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        //private readonly InventoryRepository _repository;

        //// Observable collection of ColumnSeries
        //public ObservableCollection<InventoryModel<int>> Series { get; set; }
        //public ObservableCollection<Axis> XAxes { get; set; }

        //public HomeViewModel()
        //{
        //    _repository = new InventoryRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true");
        //    Series = new ObservableCollection<InventoryModel<int>>(); // Initialize as ColumnSeries
        //    XAxes = new ObservableCollection<Axis>();

        //    LoadChartData();
        //}

        //private void LoadChartData()
        //{
        //    // Fetch equipment data from the repository
        //    var equipmentData = _repository.GetAllInventory();

        //    // Add a column series for Quantity
        //    Series.Add(new InventoryModel<int>
        //    {
        //        Name = "Quantity",
        //        Values = new ObservableCollection<int>(equipmentData.Select(e => e.Quantity).ToList()), // ObservableCollection<int> for binding
        //        TooltipLabelFormatter = value => $"Quantity: {value}"
        //    });

        //    // Add a column series for InRepair
        //    Series.Add(new InventoryModel<int>
        //    {
        //        Name = "In Repair",
        //        Values = new ObservableCollection<int>(equipmentData.Select(e => e.InRepair).ToList()),
        //        TooltipLabelFormatter = value => $"In Repair: {value}"
        //    });

        //    // Define X-Axis labels
        //    XAxes.Add(new Axis
        //    {
        //        Labels = equipmentData.Select(e => e.Name).ToArray(),
        //        LabelsRotation = 15
        //    });
        //}
    }
}