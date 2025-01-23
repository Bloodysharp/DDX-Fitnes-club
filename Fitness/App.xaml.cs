using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DDX_Fitness.Views;
using Fitness.Views;
namespace Fitness
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var LoginView = new LoginView();
            LoginView.Show();
            LoginView.IsVisibleChanged += (s, ev) =>
            {
                if (LoginView.IsVisible == false && LoginView.IsLoaded)
                {
                    var mainView = new MainExecutiveView();
                    mainView.Show();
                    LoginView.Close();
                }
            };
        }
    }
}
