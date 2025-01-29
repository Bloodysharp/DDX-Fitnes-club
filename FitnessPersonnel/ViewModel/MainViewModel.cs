using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessPersonnel.ViewModel
{
    public class MainViewModel : ViewModelBase
    {


        private ViewModelBase _currentChildView;
     
    
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public ICommand ShowHomeViewCommand { get; }
        



        public MainViewModel()
        {
       
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
          
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new PersonnelNewViewModel();
           
        }
    
    }
}
