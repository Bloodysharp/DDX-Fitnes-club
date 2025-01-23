using DDX_Fitness.Model;
using DDX_Fitness.Repository;
using DDX_Fitness.ViewModel;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitness.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
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
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowInventoryViewCommand { get; }
        public ICommand ShowWorkoutViewCommand { get; }
        public ICommand ShowPersonnelViewCommand { get; }
        public ICommand ShowStatisticlViewCommand { get; }



        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowInventoryViewCommand = new ViewModelCommand(ExecuteShowInventoryViewCommand);
            ShowWorkoutViewCommand = new ViewModelCommand(ExecuteShowWorkoutViewCommand);
            ShowPersonnelViewCommand = new ViewModelCommand(ExecuteShowPersonnelViewCommand);
            ShowStatisticlViewCommand = new ViewModelCommand(ExecuteShowStatisticlViewCommand);
            LoadCurrentUserData();
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Главное меню";
            Icon = IconChar.Home;
        }
        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Клиенты";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowInventoryViewCommand(object obj)
        {
            CurrentChildView = new InventoryViewModel();
            Caption = "Инвентарь";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowWorkoutViewCommand(object obj)
        {
            CurrentChildView = new WorkoutViewModel();
            Caption = "Расписание тренировок";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowPersonnelViewCommand(object obj)
        {
            CurrentChildView = new PersonnelViewModel();
            Caption = "Персонал";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowStatisticlViewCommand(object obj)
        {
            CurrentChildView = new StatisticViewModel();
            Caption = "Статистика";
            Icon = IconChar.UserGroup;
        }



        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $" {user.Name} {user.LastName} ";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }

    }
}
