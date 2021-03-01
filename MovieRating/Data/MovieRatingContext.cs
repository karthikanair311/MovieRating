using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Data
{
    public class MovieRatingContext : IdentityDbContext<UserDetails>
    {
        public MovieRatingContext(DbContextOptions<MovieRatingContext> options)
            : base(options)
        {
        }


       // public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<RegisterUser> RegisterUser { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ReviewerDetails> ReviewerDetails { get; set; }
        public DbSet<Rating> Rating { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserDetails>(entity =>
        //    {
        //        entity.ToTable("userDetails");

       
               
        //    });
        //}

    }



}

