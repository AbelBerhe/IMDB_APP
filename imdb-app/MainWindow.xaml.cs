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

namespace imdb_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Pages.HomePage HomePage { get; set; }
        public Pages.DirectorPage DirectorPage { get; set; }
        public Pages.FilmPage FilmPage { get; set; }
        public Pages.ShortsPage ShortsPage { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            HomePage = new Pages.HomePage();
            DirectorPage = new Pages.DirectorPage();
            FilmPage = new Pages.FilmPage();
            ShortsPage = new Pages.ShortsPage();
            mainFrame.NavigationService.Navigate(HomePage);
        }

        private void home_btn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(HomePage);

        }

        private void director_btn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(DirectorPage);

        }

        private void film_btn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(FilmPage);

        }

        private void shorts_btn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(ShortsPage);

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
