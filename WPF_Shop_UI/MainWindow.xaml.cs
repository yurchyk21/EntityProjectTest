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


namespace WPF_Shop_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowFilterNameAddWindow_Click(object sender, RoutedEventArgs e)
        {
            Window addwnd = new FilterWorkWindow();
            addwnd.Show();
        }

        private void AutoContentWindow_Click(object sender, RoutedEventArgs e)
        {
            Window autownd = new AutoCompleteWnd();
            autownd.Show();
        }

        private void ProdAddWnd_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow PAwnd = new ProductAddWindow();
            PAwnd.Show();
            //PAwnd.Photos = (PhotoCollection)(this.Resources["Photos"] as ObjectDataProvider).Data;
            //PAwnd.Photos.Path = Environment.CurrentDirectory + "\\images";
        }

    }
}
