using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public partial class Title
    {
        public string formattedTime
        {
            get
            {
                return RuntimeMinutes.ToString() + " minutes";
            }
        }

        public string formattedYear
        {
            get
            {
                return "Year: " + StartYear.ToString();
            }
        }

        public int formattedGenre
        {
            get
            {
                var gen = 0;
                foreach (Genre genre in Genres)
                {
                    gen += 1;
                }
                return gen;
            }
        }

    }
}
