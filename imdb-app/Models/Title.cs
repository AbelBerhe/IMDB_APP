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

    }
}