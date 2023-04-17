using IMDB.Data;
using Microsoft.EntityFrameworkCore;
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

namespace imdb_app.Pages
{
    /// <summary>
    /// Interaction logic for DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Page
    {
        private ImdbContext _context = new ImdbContext();
        private CollectionViewSource directorViewSource;
        public DirectorPage()
        {
            InitializeComponent();
            directorViewSource = (CollectionViewSource)FindResource(nameof(directorViewSource));
        }

        private void directorSearch_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Titles.Take(1000).Load();

            var query =
             from name in _context.Names
             select name;
            directorViewSource.Source = query.Take(2000).ToList();
        }
    }
}
