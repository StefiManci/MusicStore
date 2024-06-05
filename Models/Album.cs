namespace MusicStore.Models
{
    public class Album
    {
        /// <summary>
        /// Gets or Sets the Album Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets the Album Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or Sets the Album Author
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Gets or Sets the Album ReleaseYear
        /// </summary>
        public int ReleaseYear { get; set; }
        /// <summary>
        /// Gets or Sets the Album Genre
        /// </summary>
        public string Genre { get; set; }
    }
}