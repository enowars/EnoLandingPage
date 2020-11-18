﻿namespace EnoLandingPageBackend.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EnoLandingPageBackend.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class LandingPageDatabaseContext : DbContext
    {
        public static readonly string CONNECTIONSTRING = "Data Source=data/LandingPageDatabase.db";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LandingPageDatabaseContext(DbContextOptions<LandingPageDatabaseContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        public DbSet<LandingPageTeam> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandingPageTeam>()
                .HasIndex(t => t.Confirmed);

            modelBuilder.Entity<LandingPageTeam>()
                .HasIndex(t => t.CtftimeId)
                .IsUnique();
        }
    }
}
