﻿using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Models
{
    /// <summary>
    /// Cart Class 
    /// </summary>
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Album album)
        {
            CartLine line = lineCollection
            .Where(p => p.Album.Title == album.Title)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Album = album,
                });
            }
        }
        public virtual void RemoveLine(Album music) =>
        lineCollection.RemoveAll(l => l.Album.Title == music.Title);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}