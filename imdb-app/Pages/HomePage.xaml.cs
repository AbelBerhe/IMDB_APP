using IMDB.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class HomePage : Page
    {
        private ImdbContext _context = new ImdbContext();
        private CollectionViewSource homeViewSource;

        public HomePage()
        {
            InitializeComponent();
            homeViewSource = (CollectionViewSource)FindResource(nameof(homeViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Titles.OrderByDescending(t => t.Rating).Take(3).Load();
            homeViewSource.Source = _context.Titles.Local.ToObservableCollection();
        }
       
    }
}

