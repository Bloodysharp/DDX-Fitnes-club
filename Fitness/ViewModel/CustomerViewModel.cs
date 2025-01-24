using DDX_Fitness.Repository;
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
    public class CustomerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly VisitorsRepository _repository;
        private ObservableCollection<VisitorsModel> _visitors;

        public ObservableCollection<VisitorsModel> Visitors
        {
            get => _visitors;
            set
            {
                _visitors = value;
                OnPropertyChanged(nameof(Visitors));
            }
        }

        public CustomerViewModel()
        {
            _repository = new VisitorsRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true");
           
            LoadVisitors();
        }

        private void LoadVisitors()
        {
            var visitorList = _repository.GetAllVisitors();
            Visitors = new ObservableCollection<VisitorsModel>(visitorList);
        }
    }
}
