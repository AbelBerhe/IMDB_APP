namespace imdb_app.Models
{
    public partial class Title
    {
        public string formattedTime
        {
            get
            {
                return "Length: " + RuntimeMinutes.ToString() + " minutes";
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