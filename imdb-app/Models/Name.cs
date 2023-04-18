using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_app.Models
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
                    else
                    {
                        years += " -";
                    }
                }
                return "Directed By: " + PrimaryName + ", " + years;
            }
        }
    }
}
