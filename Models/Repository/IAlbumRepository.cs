using System.Collections.Generic;

namespace MusicStore.Models.Repository
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// Interface to implement Album IEnumerable
        /// </summary>
        IEnumerable<Album> Albums { get; }
        void SaveAlbum(Album album);
        Album DeleteProduct(int Id);
    }
}
