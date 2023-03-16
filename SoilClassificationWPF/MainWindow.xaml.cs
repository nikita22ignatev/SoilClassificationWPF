using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoilClassificationWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HomeBtn.IsChecked = true;
            ContentFrame.Content = new MainPage();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenCalculatePage(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new CalculatePage();
        }

        private void MainPage(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new MainPage();
        }
    }
}
