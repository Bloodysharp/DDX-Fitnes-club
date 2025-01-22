using DDX_Fitness.Model;
using DDX_Fitness.Repository;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDX_Fitness.ViewModel
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
        public ICommand ShowOrderViewCommand { get; }
        public ICommand ShowTransactionViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            //ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            //ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            //ShowTransactionViewCommand = new ViewModelCommand(ExecuteOrderHomeViewCommand);
            //ShowOrderViewCommand = new ViewModelCommand(ExecuteShowTransactionViewCommand);
            LoadCurrentUserData();
        }
        //private void ExecuteShowCustomerViewCommand(object obj)
        //{
        //    CurrentChildView = new CustomerViewModel();
        //    Caption = "Customers";
        //    Icon = IconChar.UserGroup;
        //}
        //private void ExecuteShowHomeViewCommand(object obj)
        //{
        //    CurrentChildView = new HomeViewModel();
        //    Caption = "Home";
        //    Icon = IconChar.Home;
        //}
        //private void ExecuteOrderHomeViewCommand(object obj)
        //{
        //    CurrentChildView = new OrderViewModel();
        //    Caption = "Orders";
        //    Icon = IconChar.Truck;
        //}
        //private void ExecuteShowTransactionViewCommand(object obj)
        //{
        //    CurrentChildView = new TransactionViewModel();
        //    Caption = "Transaction";
        //    Icon = IconChar.ShoppingBag;
        //}

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
