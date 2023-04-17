using IMDB.Data;
using IMDB.Models;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace imdb_app.Pages
{
    /// <summary>
    /// Interaction logic for ShortsPage.xaml
    /// </summary>
    public partial class ShortsPage : Page
    {
        private ImdbContext _context = new ImdbContext();
        private CollectionViewSource shortsViewSource;
        public ShortsPage()
        {
            InitializeComponent();
            shortsViewSource = (CollectionViewSource)FindResource(nameof(shortsViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Titles.Load();
            _context.Ratings.Load();
        }

        private void shortSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = shortSearch.Text;
            var query =
                from title in _context.Titles
                join rating in _context.Ratings on title.TitleId equals rating.TitleId
                join principal in _context.Principals on title.TitleId equals principal.TitleId
                join name in _context.Names on principal.NameId equals name.NameId
                where (title.RuntimeMinutes < 45) && title.PrimaryTitle.Contains(searchTerm) && name.PrimaryProfession.Contains("director")
                select new
                {
                    title,
                    rating,
                    name
                };
            shortSearchResult.ItemsSource = query.Take(1000).ToList();

        }


    }
}


