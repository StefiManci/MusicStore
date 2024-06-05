using System.Collections.Generic;
using MusicStore.Models.Database;

namespace MusicStore.Models.Repository
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
