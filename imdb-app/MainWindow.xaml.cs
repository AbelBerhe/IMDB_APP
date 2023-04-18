using System.Windows;

namespace imdb_app
{
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
