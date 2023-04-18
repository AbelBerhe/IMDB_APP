using imdb_app.Data;
using imdb_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

        }

        private void shortSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = shortSearch.Text;
            var query =
                from title in _context.Titles
                join rating in _context.Ratings on title.TitleId equals rating.TitleId
                join principal in _context.Principals on title.TitleId equals principal.TitleId
                join name in _context.Names on principal.NameId equals name.NameId
                where title.RuntimeMinutes < 45 && rating.AverageRating != null && principal.JobCategory == "director" && title.PrimaryTitle.Contains(searchTerm)
                group new { title, rating, name } by title.PrimaryTitle into nameGroup
                select new
                {
                    Title = nameGroup.Key,
                    Director = nameGroup.Select(t => t.name.formattedDirector).FirstOrDefault(),
                    Year = nameGroup.Select(t => t.title.formattedYear).FirstOrDefault(),
                    Time = nameGroup.Select(t => t.title.formattedTime).FirstOrDefault(),
                    Rating = nameGroup.Select(t => t.rating.formattedRating).FirstOrDefault(),

                };

            shortsViewSource.Source = query.Take(1000).ToList();

        }
    }
}


