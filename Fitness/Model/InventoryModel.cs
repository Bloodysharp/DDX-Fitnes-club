using DDX_Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class InventoryModel : ViewModelBase
    {
        private string _name;
        private string _status;
        private int _quantity;
        private int _inRepair;
        private decimal _price;

        public Guid ID { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public int InRepair
        {
            get => _inRepair;
            set
            {
                _inRepair = value;
                OnPropertyChanged(nameof(InRepair));
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }        
    }
}
