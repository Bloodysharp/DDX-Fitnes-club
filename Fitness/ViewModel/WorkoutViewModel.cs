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
    public class WorkoutViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly WorkoutRepository _repository;
        private ObservableCollection<WorkoutModel> _visitors;

        public ObservableCollection<WorkoutModel> Visitors
        {
            get => _visitors;
            set
            {
                _visitors = value;
                OnPropertyChanged(nameof(Visitors));
            }
        }

        public WorkoutViewModel()
        {
            _repository = new WorkoutRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true");

            LoadWorkout();
        }

        private void LoadWorkout()
        {
            var visitorList = _repository.GetAllWorkout();
            Visitors = new ObservableCollection<WorkoutModel>(visitorList);
        }
    }
}
