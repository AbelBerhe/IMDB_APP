using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public partial class Name
    {
        public string formattedDirector
        {
            get
            {
                var years = "";
                if (BirthYear != null)
                {
                    years += BirthYear.ToString();
                    if (DeathYear != null)
                    {
                        years += " - " + DeathYear.ToString();
                    }
                }
                return "Directed By: " + PrimaryName + ", " + years;
            }
        }
    }
}
