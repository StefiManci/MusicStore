using System.Collections.Generic;

namespace MusicStore.Models
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Album> Albums { get; }
    }
}
