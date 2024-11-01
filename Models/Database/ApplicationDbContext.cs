﻿using Microsoft.EntityFrameworkCore;
namespace MusicStore.Models.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Album> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
