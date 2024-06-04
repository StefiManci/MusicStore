namespace MusicStore.Models
{
    public class Album
    {
        //hiq spaces
        //ver komente per cdo property
        //ndrysho pozicionet e klasave tek Models
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the album release year.
        /// </summary>
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}
