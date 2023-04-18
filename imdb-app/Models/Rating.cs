using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_app.Models

{
    public partial class Rating
    {
        public string formattedRating
        {
            get
            {

                return " " + AverageRating.ToString() + " / 10.00 ";
            }
        }
    }
}
