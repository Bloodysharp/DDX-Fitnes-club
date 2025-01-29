using DDX_Fitness.CustomControls.Notify;
using Fitness.EntityFramework.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitness.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPersonnelView.xaml
    /// </summary>
    public partial class AddPersonnelView : Window
    {
        private readonly Trainers _newTrainers = new Trainers();
        public AddPersonnelView(Trainers selectedTrainers)
        {
            InitializeComponent();
            if (selectedTrainers != null) _newTrainers = selectedTrainers;
            DataContext = _newTrainers;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
        private SolidColorBrush HextoSolidBrush(string Hex)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(Hex));
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //if (string.IsNullOrWhiteSpace(IDtxtBox.Text) ||
                //    string.IsNullOrWhiteSpace(FullNameTxtBox.Text) ||
                //    string.IsNullOrWhiteSpace(EmailTxtBox.Text) ||
                //    SBCTypeComboBox.SelectedItem == null ||
                //    SBCStatusComboBox.SelectedItem == null ||
                //    string.IsNullOrWhiteSpace(StartTxtBox.Text) ||
                //    string.IsNullOrWhiteSpace(EndtxtBox.Text))
                //{
                //    throw new Exception("Пожалуйста, заполните все поля.");
                //}

                var obj = new Trainers
                {
                    ID = Guid.NewGuid(),
                    FullName = FullNameTxtBox.Text,
                    Email = EmailTxtBox.Text,
                    PhoneNumber = PhoneTxtBox.Text,
                    Salary = decimal.TryParse(salarytxtbox.Text, out var price) ? price : 0,
                    ExperienceYears = int.Parse(exptxtbox.Text),
                    //SubscriptionStart = DateTime.Parse(StartTxtBox.Text),
                    //SubscriptionEnd = DateTime.Parse(EndtxtBox.Text),
                    Specialty = specstxtbox.Text
                };

                FitnessGymEntities.GetContext().Trainers.Add(obj);
                FitnessGymEntities.GetContext().SaveChanges();

                var success = new Notification(
                    "Success",
                    "All changes saved!",
                    "/Assets/Images/success_icon.png",
                    (LinearGradientBrush)this.Resources["GreenGradient"],
                    HextoSolidBrush("#36AE3B")
                );
                success.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                var error = new Notification(
                    "Error!",
                    ex.Message,
                    "/Assets/Images/Error_icon.png",
                    (LinearGradientBrush)this.Resources["RedGradient"],
                    HextoSolidBrush("#F24A50")
                );
                error.Show();
            }

        }
    }
}