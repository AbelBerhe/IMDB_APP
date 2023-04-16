using IMDB.Data;
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
    /// Interaction logic for ShortsPage.xaml
    /// </summary>
    public partial class ShortsPage : Page
    {
        private ImdbContext _context = new ImdbContext();
        private CollectionViewSource shortsViewSource;
        public ShortsPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void shortSearch_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
