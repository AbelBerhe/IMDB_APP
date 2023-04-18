using imdb_app.Data;
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
    /// Interaction logic for FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        private ImdbContext _context = new ImdbContext();
        private CollectionViewSource filmViewSource;

        public FilmPage()
        {
            InitializeComponent();
            filmViewSource = (CollectionViewSource)FindResource(nameof(filmViewSource));

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
         //_context.Titles.Where(title => title.RuntimeMinutes > 45).Take(20000).Load();
         //filmViewSource.Source = _context.Titles.Local.ToObservableCollection();

        }

        private void filmSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = filmSearch.Text;
            var query =
                        from title in _context.Titles
                        join rating in _context.Ratings on title.TitleId equals rating.TitleId
                        join principal in _context.Principals on title.TitleId equals principal.TitleId
                        join name in _context.Names on principal.NameId equals name.NameId
                        where title.RuntimeMinutes > 45 && rating.AverageRating != null && principal.JobCategory == "director" && title.PrimaryTitle.Contains(searchTerm)
                        group new { title, rating, name } by title.PrimaryTitle into nameGroup
                        select new
                        {
                            Title = nameGroup.Key,
                            Director = nameGroup.Select(t => t.name.formattedDirector).FirstOrDefault(),
                            Year = nameGroup.Select(t => t.title.formattedYear).FirstOrDefault(),
                            Time = nameGroup.Select(t => t.title.formattedTime).FirstOrDefault(),
                            Rating = nameGroup.Select(t => t.rating.formattedRating).FirstOrDefault(),
                            Genres = nameGroup.Select(t => t.title.Genres).FirstOrDefault()

                        };

                    filmViewSource.Source = query.Take(1000).ToList();
        }
    }
}



