using System.Collections.Generic;

namespace MusicStore.Models.Repository
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Album> Albums { get; }
    }
}
