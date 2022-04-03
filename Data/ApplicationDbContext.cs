﻿using Microsoft.EntityFrameworkCore;
using PlatformService.models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }

    }
}