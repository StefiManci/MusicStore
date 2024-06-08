using System.Collections.Generic;
using System.Linq;
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
        public void SaveAlbum(Album album)
        {
            if (album.Id == 0)
            {
                context.Musics.Add(album);
            }
            else
            {
                Album dbEntry = context.Musics
                    .FirstOrDefault(p => p.Id == album.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = album.Title;
                    dbEntry.Author = album.Author;
                    dbEntry.ReleaseYear = album.ReleaseYear;
                    dbEntry.Genre = album.Genre;
                }
            }
            context.SaveChanges();
        }
        public Album DeleteProduct(int Id)
        {
            Album dbEntry = context.Musics
            .FirstOrDefault(p => p.Id == Id);
            if (dbEntry != null)
            {
                context.Musics.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}




