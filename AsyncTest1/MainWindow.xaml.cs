using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncTest1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void buttonAsync_Click(object sender, RoutedEventArgs e)
        {
            buttonAsync.IsEnabled = false;
            var slowTask = Task<string>.Factory.StartNew(() => SlowDude());
            textBoxResults.Text += "Awaiting Task...\r\n";
            await slowTask;
            textBoxResults.Text += slowTask.Result;
            buttonAsync.IsEnabled = true;
        }

        private string SlowDude()
        {
            Thread.Sleep(2000);
            return "Ta-dam! Here I am!\r\n";
        }
    }
}
