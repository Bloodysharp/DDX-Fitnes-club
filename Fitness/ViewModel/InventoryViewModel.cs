using DDX_Fitness.ViewModel;
using Fitness.Model;
using Fitness.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.ViewModel
{
    public class InventoryViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly InventoryRepository _repository;
        private ObservableCollection<InventoryModel> _inventory;

        public ObservableCollection<InventoryModel> Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
                OnPropertyChanged(nameof(Inventory));
            }
        }
        public InventoryViewModel()
        {
            _repository = new InventoryRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true");

            LoadInventory();
        }

        private void LoadInventory()
        {
            var InventoryList = _repository.GetAllInventory();
            Inventory = new ObservableCollection<InventoryModel>(InventoryList);
        }
    }
}

