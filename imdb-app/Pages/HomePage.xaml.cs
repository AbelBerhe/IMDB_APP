using IMDB.Data;
using IMDB.Models;
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

            homeViewSource.Source = _context.Titles.Local.ToObservableCollection();
        }

        private void rando_btn_Click(object sender, RoutedEventArgs e)
        {
            _context.Titles.Load();

            var query =
                 from title in _context.Titles
                 join rating in _context.Ratings on title.TitleId equals rating.TitleId
                 join principal in _context.Principals on title.TitleId equals principal.TitleId
                 join name in _context.Names on principal.NameId equals name.NameId
                 where rating.AverageRating != null && principal.JobCategory == "director"
                 group new { title, rating, name } by title.PrimaryTitle into nameGroup
                 select new
                 {
                     Title = nameGroup.Key,
                     Director = nameGroup.Select(t => t.name.formattedDirector).FirstOrDefault(),
                     Year = nameGroup.Select(t => t.title.formattedYear).FirstOrDefault(),
                     Time = nameGroup.Select(t => t.title.formattedTime).FirstOrDefault(),
                     Rating = nameGroup.Select(t => t.rating.formattedRating).FirstOrDefault(),

                 };

            homeViewSource.Source = query.OrderBy(x => Guid.NewGuid()).Take(1).ToList();

        }
    }
}

