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
    public class PersonnelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly PersonnelRepository _repository;
        private ObservableCollection<PersonnelModel> _personnel;

        public ObservableCollection<PersonnelModel> Personnels
        {
            get => _personnel;
            set
            {
                _personnel = value;
                OnPropertyChanged(nameof(Personnels));
            }
        }

        public PersonnelViewModel()
        {
            _repository = new PersonnelRepository("Server=HOME-PC\\SQLEXPRESS; Database=FitnessGym; Integrated Security=true");

            LoadPersonnel();
        }

        private void LoadPersonnel()
        {
            var personnelList = _repository.GetAllPersonnel();
            Personnels = new ObservableCollection<PersonnelModel>(personnelList);
        }
    }
}

