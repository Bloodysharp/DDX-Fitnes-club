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
        public ICommand ShowDocumentViewCommand { get; }



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
            ShowDocumentViewCommand = new ViewModelCommand(ExecuteShowDocumentViewCommand);
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
            Icon = IconChar.Dumbbell;
        }
        private void ExecuteShowWorkoutViewCommand(object obj)
        {
            CurrentChildView = new WorkoutViewModel();
            Caption = "Расписание тренировок";
            Icon = IconChar.CalendarTimes;
        }
        private void ExecuteShowPersonnelViewCommand(object obj)
        {
            CurrentChildView = new PersonnelViewModel();
            Caption = "Персонал";
            Icon = IconChar.UserTie;
        }
        private void ExecuteShowStatisticlViewCommand(object obj)
        {
            CurrentChildView = new StatisticViewModel();
            Caption = "Статистика";
            Icon = IconChar.Wallet;
        }
        private void ExecuteShowDocumentViewCommand(object obj)
        {
            CurrentChildView = new DocumentViewModel();
            Caption = "Договор";
            Icon = IconChar.Dochub;
        }


        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.FullName;
                CurrentUserAccount.DisplayName = $"ФИО: {user.FullName}, Роль: {user.Role}";
                CurrentUserAccount.ProfilePicture = /*user.profilePics;*/ null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }

    }
}
