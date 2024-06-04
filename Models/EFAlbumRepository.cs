using System.Collections.Generic;

namespace MusicStore.Models
{
    public class EFAlbumRepository : IAlbumRepository
    {
        private ApplicationDbContext context;

        public EFAlbumRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Album> Albums => context.Musics;
    }
}
