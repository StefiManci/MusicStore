using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="Please Enter Album Title")]
        public string Title { get; set; }
        /// <summary>
        /// Gets or Sets the Album Author
        /// </summary>
        [Required(ErrorMessage = "Please Enter Album Author")]
        public string Author { get; set; }
        /// <summary>
        /// Gets or Sets the Album ReleaseYear
        /// </summary>
        [Required(ErrorMessage = "Please Enter Album Release Year")]
        public int ReleaseYear { get; set; }
        /// <summary>
        /// Gets or Sets the Album Genre
        /// </summary>
        [Required(ErrorMessage ="Please Enter Album Genre")]
        public string Genre { get; set; }
    }
}