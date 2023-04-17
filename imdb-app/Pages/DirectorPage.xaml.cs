using IMDB.Data;
using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            string searchTerm = directorSearch.Text;
            var query =
                from name in _context.Names.Include(n => n.Titles) // Eagerly load the Titles relationship
                where (name.PrimaryProfession == null || name.PrimaryProfession.Contains("director"))
                    && (string.IsNullOrEmpty(searchTerm) || name.PrimaryName == null || name.PrimaryName.Contains(searchTerm))
                select name;
            directorViewSource.Source = query.Take(2000).ToList();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
                from name in _context.Names
                where name.PrimaryProfession == null || name.PrimaryProfession.Contains("director")
                select name;
            directorViewSource.Source = query.Take(2000).ToList();
        }
        private void Expander_Loaded(object sender, RoutedEventArgs e)
        {
            Expander? expander = sender as Expander;
            if (expander != null)
            {
                Name? director = expander.DataContext as Name;
                if (director != null && (director.PrimaryProfession == null || director.PrimaryProfession.Contains("director")))
                {
                    // Retrieve the titles associated with the director
                    var titles = _context.Principals
                        .Where(p => p.NameId == director.NameId && p.JobCategory == "director")
                        .Join(_context.Titles, p => p.TitleId, t => t.TitleId, (p, t) => t)
                        .Take(10)
                        .ToList(); // Limit to 10 titles


                    // Update the ItemsSource of the ListView inside the Expander to the titles
                    ListView? titleListView = expander.FindName("titleListView") as ListView;
                    if (titleListView != null)
                    {
                        titleListView.ItemsSource = titles;
                    }

                }
            }
        }
    }
}
